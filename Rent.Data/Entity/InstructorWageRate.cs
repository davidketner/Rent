using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorWageRate
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int WageRateId { get; set; }
        public virtual WageRate WageRate { get; set; }
        public bool Default { get; set; }
    }
}
