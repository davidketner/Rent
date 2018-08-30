using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Ticket : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RentalId { get; set; }

        public virtual Rental Rental { get; set; }
        public virtual ICollection<InstructorTicket> Instructors { get; set; }
    }
}
