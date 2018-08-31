using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface ILanguageRepository : IGenericRepository<Language, int>
    {
    }

    public class LanguageRepository : GenericRepository<Language, RentDbContext, int>, ILanguageRepository
    {
        public LanguageRepository(RentDbContext context) : base(context)
        {
        }
    }
}
