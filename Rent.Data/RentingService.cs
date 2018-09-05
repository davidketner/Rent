using Rent.Data.Repositories;

namespace Rent.Data
{
    public class RentingService : RentService
    {
        public RentDbContext DbContext { get; }

        public RentingService(RentDbContext db) : base()
        {
            DbContext = db;
            Companies = new CompanyRepository(db);
            Rentals = new RentalRepository(db);
            Instructors = new InstructorRepository(db);
            Languages = new LanguageRepository(db);
            LanguageLevels = new LanguageLevelRepository(db);
            Tickets = new TicketRepository(db);
            WageRates = new WageRateRepository(db);
            Expertises = new ExpertiseRepository(db);
            ExpertiseLevels = new ExpertiseLevelRepository(db);
        }

        public override void Commit()
        {
            DbContext.SaveChanges();
        }

        public override void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
