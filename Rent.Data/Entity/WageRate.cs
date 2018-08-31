using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class WageRate : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Rate { get; set; }
        public bool Percental { get; set; }

        public virtual ICollection<InstructorWageRate> Instructors { get; set; }
    }
}
