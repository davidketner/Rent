using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course, int>
    {
    }

    public class CourseRepository : GenericRepository<Course, RentDbContext, int>, ICourseRepository
    {
        public CourseRepository(RentDbContext context) : base(context)
        {
        }
    }
}
