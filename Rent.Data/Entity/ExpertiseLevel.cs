using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class ExpertiseLevel : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Shortname { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
