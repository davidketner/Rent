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
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<WageRate> WageRates { get; set; }
        public DbSet<InstructorTicket> InstructorTickets { get; set; }
        public DbSet<InstructorWageRate> InstructorWageRates { get; set; }
        public DbSet<InstructorAvailability> InstructorAvailabilities { get; set; }
        public DbSet<InstructorPayment> InstructorPayments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<RentalPlace> RentalPlaces { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }

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

            builder.Entity<InstructorTicket>()
                   .HasKey(it => new { it.InstructorId, it.TicketId });

            builder.Entity<InstructorTicket>()
                  .HasOne(it => it.Instructor)
                  .WithMany(i => i.Tickets)
                  .HasForeignKey(it => it.InstructorId);

            builder.Entity<InstructorTicket>()
                   .HasOne(it => it.Ticket)
                   .WithMany(t => t.Instructors)
                   .HasForeignKey(it => it.TicketId);

            builder.Entity<InstructorWageRate>()
                   .HasKey(iw => new { iw.InstructorId, iw.WageRateId });

            builder.Entity<InstructorWageRate>()
                  .HasOne(iw => iw.Instructor)
                  .WithMany(i => i.WageRates)
                  .HasForeignKey(iw => iw.InstructorId);

            builder.Entity<InstructorWageRate>()
                   .HasOne(iw => iw.WageRate)
                   .WithMany(w => w.Instructors)
                   .HasForeignKey(iw => iw.WageRateId);

            builder.Entity<InstructorCourse>()
                   .HasKey(ic => new { ic.InstructorId, ic.CourseId });

            builder.Entity<InstructorCourse>()
                  .HasOne(ic => ic.Instructor)
                  .WithMany(i => i.Courses)
                  .HasForeignKey(ic => ic.InstructorId);

            builder.Entity<InstructorCourse>()
                   .HasOne(ic => ic.Course)
                   .WithMany(c => c.Instructors)
                   .HasForeignKey(ic => ic.CourseId);

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
