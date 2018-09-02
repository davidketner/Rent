using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Company : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }

        private ICollection<Rental> rentals;
        public virtual ICollection<Rental> Rentals
        {
            get { return rentals ?? (rentals = new HashSet<Rental>()); }
            set { rentals = value; }
        }
    }
}
