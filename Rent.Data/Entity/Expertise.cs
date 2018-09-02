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

        private ICollection<InstructorExpertise> instructors;
        public virtual ICollection<InstructorExpertise> Instructors
        {
            get { return instructors ?? (instructors = new HashSet<InstructorExpertise>()); }
            set { instructors = value; }
        }

        private ICollection<Course> courses;
        public virtual ICollection<Course> Courses
        {
            get { return courses ?? (courses = new HashSet<Course>()); }
            set { courses = value; }
        }
    }
}
