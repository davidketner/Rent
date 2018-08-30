using Rent.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data
{
    public interface IRentService
    {
        IRentalRepository Rentals { get; set; }
        void Dispose();
        void Commit();
    }

    public class RentService : IRentService
    {
        public IRentalRepository Rentals { get; set; }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
