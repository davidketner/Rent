using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class InstructorAvailability : BaseEntity<int>, ISoftDeletable
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
