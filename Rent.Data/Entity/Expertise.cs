using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Expertise : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Shortname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InstructorExpertise> Instructors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
