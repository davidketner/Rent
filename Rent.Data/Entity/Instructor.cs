using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Instructor : BaseEntity<int>, ISoftDeletable
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string MobilPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual ICollection<InstructorRental> Rentals { get; set; }
        public virtual ICollection<InstructorLanguage> Languages { get; set; }
        public virtual ICollection<InstructorExpertise> Expertises { get; set; }
    }
}
