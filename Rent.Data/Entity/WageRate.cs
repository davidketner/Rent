using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class WageRate : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public bool Percental { get; set; }

        public virtual ICollection<InstructorWageRate> Instructors { get; set; }
    }
}
