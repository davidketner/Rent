using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IExpertiseRepository : IGenericRepository<Expertise, int>
    {
    }

    public class ExpertiseRepository : GenericRepository<Expertise, RentDbContext, int>, IExpertiseRepository
    {
        public ExpertiseRepository(RentDbContext context) : base(context)
        {
        }
    }
}