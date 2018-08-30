using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Company : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
