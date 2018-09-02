using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Rental : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Shortname { get; set; }
        [Required]
        public string Name { get; set; }
        public string BusinessId { get; set; }
        public string TaxId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        private ICollection<RentalPlace> places;
        public virtual ICollection<RentalPlace> Places
        {
            get { return places ?? (places = new HashSet<RentalPlace>()); }
            set { places = value; }
        }

        private ICollection<InstructorRental> instructors;
        public virtual ICollection<InstructorRental> Instructors
        {
            get { return instructors ?? (instructors = new HashSet<InstructorRental>()); }
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
