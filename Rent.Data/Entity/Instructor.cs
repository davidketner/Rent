using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Instructor : BaseEntity<int>, ISoftDeletable
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        public string MobilPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }

        public virtual ICollection<InstructorRental> Rentals { get; set; }
        public virtual ICollection<InstructorLanguage> Languages { get; set; }
        public virtual ICollection<InstructorExpertise> Expertises { get; set; }
        public virtual ICollection<InstructorTicket> Tickets { get; set; }
        public virtual ICollection<InstructorAvailability> Availabilities { get; set; }
        public virtual ICollection<InstructorPayment> InstructorPayments { get; set; }
        public virtual ICollection<InstructorCourse> Courses { get; set; }


        private ICollection<InstructorWageRate> wageRates;
        public virtual ICollection<InstructorWageRate> WageRates
        {
            get { return wageRates ?? (wageRates = new HashSet<InstructorWageRate>()); }
            set { wageRates = value; }
        }
    }
}
