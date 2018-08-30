using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class InstructorPayment : BaseEntity<int>, ISoftDeletable
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
