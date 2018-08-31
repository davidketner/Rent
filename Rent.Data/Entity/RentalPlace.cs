using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class RentalPlace : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int RentalId { get; set; }
        public virtual Rental Rental { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
