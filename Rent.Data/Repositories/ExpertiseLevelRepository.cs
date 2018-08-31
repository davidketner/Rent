using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IExpertiseLevelRepository : IGenericRepository<ExpertiseLevel, int>
    {
    }

    public class ExpertiseLevelRepository : GenericRepository<ExpertiseLevel, RentDbContext, int>, IExpertiseLevelRepository
    {
        public ExpertiseLevelRepository(RentDbContext context) : base(context)
        {
        }
    }
}