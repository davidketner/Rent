using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IRentalRepository : IGenericRepository<Rental, int>
    {
    }

    public class RentalRepository : GenericRepository<Rental, RentDbContext, int>, IRentalRepository
    {
        public RentalRepository(RentDbContext context) : base(context)
        {
        }
    }
}
