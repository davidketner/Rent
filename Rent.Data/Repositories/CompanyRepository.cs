using Rent.Data.Entity;
using System.Linq;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company, int>
    {
        Company GetCompany { get; }
    }

    public class CompanyRepository : GenericRepository<Company, RentDbContext, int>, ICompanyRepository
    {
        private readonly RentDbContext context;

        public CompanyRepository(RentDbContext context) : base(context)
        {
            this.context = context;
        }

        public Company GetCompany => context.Companies.FirstOrDefault(x => x.Id > 0);
    }
}