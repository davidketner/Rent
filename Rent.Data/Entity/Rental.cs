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

        public virtual ICollection<InstructorRental> Instructors { get; set; }
        public virtual ICollection<RentalPlace> Places { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
