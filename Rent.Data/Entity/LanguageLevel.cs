using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class LanguageLevel : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }

        private ICollection<Course> courses;
        public virtual ICollection<Course> Courses
        {
            get { return courses ?? (courses = new HashSet<Course>()); }
            set { courses = value; }
        }
    }
}
