using Microsoft.EntityFrameworkCore;
using Rent.Data.Entity;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using UtilityLibrary;

namespace Rent.Data
{
    public class RentDbContext : DbContext
    {
        public RentDbContext(DbContextOptions<RentDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RentDB;Trusted_Connection=True;");
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorRental> InstructorRentals { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<InstructorLanguage> InstructorLanguages { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<ExpertiseLevel> ExpertiseLevels { get; set; }
        public DbSet<InstructorExpertise> InstructorExpertises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType) == true)
                {
                    entityType.GetOrAddProperty("IsDeleted", typeof(bool));

                    var parameter = Expression.Parameter(entityType.ClrType);

                    var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                    var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                    BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                    var lambda = Expression.Lambda(compareExpression, parameter);

                    builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            builder.Entity<InstructorRental>()
                   .HasKey(ir => new { ir.InstructorId, ir.RentalId });

            builder.Entity<InstructorRental>()
                   .HasOne(ir => ir.Instructor)
                   .WithMany(i => i.Rentals)
                   .HasForeignKey(ir => ir.InstructorId);

            builder.Entity<InstructorRental>()
                   .HasOne(ir => ir.Rental)
                   .WithMany(r => r.Instructors)
                   .HasForeignKey(ir => ir.RentalId);

            builder.Entity<InstructorLanguage>()
                   .HasKey(il => new { il.InstructorId, il.LanguageId });

            builder.Entity<InstructorLanguage>()
                  .HasOne(il => il.Instructor)
                  .WithMany(i => i.Languages)
                  .HasForeignKey(il => il.InstructorId);

            builder.Entity<InstructorLanguage>()
                   .HasOne(il => il.Language)
                   .WithMany(l => l.Instructors)
                   .HasForeignKey(il => il.LanguageId);

            builder.Entity<InstructorExpertise>()
                   .HasKey(ie => new { ie.InstructorId, ie.ExpertiseId });

            builder.Entity<InstructorExpertise>()
                  .HasOne(ie => ie.Instructor)
                  .WithMany(i => i.Expertises)
                  .HasForeignKey(ie => ie.InstructorId);

            builder.Entity<InstructorExpertise>()
                   .HasOne(ie => ie.Expertise)
                   .WithMany(e => e.Instructors)
                   .HasForeignKey(ie => ie.ExpertiseId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is ISoftDeletable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["IsDeleted"] = false;
                            entry.CurrentValues["Created"] = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.CurrentValues["Updated"] = DateTime.Now;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["Deleted"] = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
