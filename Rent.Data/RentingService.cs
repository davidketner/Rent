using Rent.Data.Repositories;

namespace Rent.Data
{
    public class RentingService : RentService
    {
        public RentDbContext DbContext { get; }

        public RentingService(RentDbContext db) : base()
        {
            DbContext = db;
            Rentals = new RentalsRepository(db);
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
