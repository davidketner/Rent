using Rent.Data.Entity;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket, int>
    {
    }

    public class TicketRepository : GenericRepository<Ticket, RentDbContext, int>, ITicketRepository
    {
        public TicketRepository(RentDbContext context) : base(context)
        {
        }
    }
}