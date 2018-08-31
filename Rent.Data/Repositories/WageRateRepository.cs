using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IWageRateRepository : IGenericRepository<WageRate, int>
    {
    }

    public class WageRateRepository : GenericRepository<WageRate, RentDbContext, int>, IWageRateRepository
    {
        public WageRateRepository(RentDbContext context) : base(context)
        {
        }
    }
}
