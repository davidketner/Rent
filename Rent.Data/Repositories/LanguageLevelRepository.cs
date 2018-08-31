using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface ILanguageLevelRepository : IGenericRepository<LanguageLevel, int>
    {
    }

    public class LanguageLevelRepository : GenericRepository<LanguageLevel, RentDbContext, int>, ILanguageLevelRepository
    {
        public LanguageLevelRepository(RentDbContext context) : base(context)
        {
        }
    }
}
