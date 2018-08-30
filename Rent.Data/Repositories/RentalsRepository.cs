using Rent.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Repositories
{
    public interface IRentalsRepository : IGenericRepository<Rental, int>
    {
    }

    public class RentalsRepository : GenericRepository<Rental, RentDbContext, int>, IRentalsRepository
    {
        public RentalsRepository(RentDbContext context) : base(context)
        {
        }
    }
}
