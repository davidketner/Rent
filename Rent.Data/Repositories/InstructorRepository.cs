using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IInstructorRepository : IGenericRepository<Instructor, int>
    {
    }

    public class InstructorRepository : GenericRepository<Instructor, RentDbContext, int>, IInstructorRepository
    {
        public InstructorRepository(RentDbContext context) : base(context)
        {
        }
    }
}
