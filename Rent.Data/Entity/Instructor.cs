using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        private ICollection<InstructorRental> rentals;
        public virtual ICollection<InstructorRental> Rentals
        {
            get { return rentals ?? (rentals = new HashSet<InstructorRental>()); }
            set { rentals = value; }
        }

        private ICollection<InstructorLanguage> languages;
        public virtual ICollection<InstructorLanguage> Languages
        {
            get { return languages ?? (languages = new HashSet<InstructorLanguage>()); }
            set { languages = value; }
        }

        private ICollection<InstructorTicket> tickets;
        public virtual ICollection<InstructorTicket> Tickets
        {
            get { return tickets ?? (tickets = new HashSet<InstructorTicket>()); }
            set { tickets = value; }
        }

        private ICollection<InstructorAvailability> availabilities;
        public virtual ICollection<InstructorAvailability> Availabilities
        {
            get { return availabilities ?? (availabilities = new HashSet<InstructorAvailability>()); }
            set { availabilities = value; }
        }

        private ICollection<InstructorPayment> payments;
        public virtual ICollection<InstructorPayment> Payments
        {
            get { return payments ?? (payments = new HashSet<InstructorPayment>()); }
            set { payments = value; }
        }

        private ICollection<InstructorCourse> courses;
        public virtual ICollection<InstructorCourse> Courses
        {
            get { return courses ?? (courses = new HashSet<InstructorCourse>()); }
            set { courses = value; }
        }

        private ICollection<InstructorWageRate> wageRates;
        public virtual ICollection<InstructorWageRate> WageRates
        {
            get { return wageRates ?? (wageRates = new HashSet<InstructorWageRate>()); }
            set { wageRates = value; }
        }

        private ICollection<InstructorExpertise> expertises;
        public virtual ICollection<InstructorExpertise> Expertises
        {
            get { return expertises ?? (expertises = new HashSet<InstructorExpertise>()); }
            set { expertises = value; }
        }

        public bool IsAvailable(DateTime from, DateTime to)
        {
            if(Availabilities.Any(x => x.From.Date <= from.Date && x.To.Date >= to.Date && TimeSpan.Compare(x.From.TimeOfDay, from.TimeOfDay) <= 0 && TimeSpan.Compare(x.To.TimeOfDay, to.TimeOfDay) >= 0))
            {
                if(!Courses.Any(x => x.Course.From < to && from < x.Course.To))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasExpertise(Expertise expertise, ExpertiseLevel expertiseLevel)
        {
            if(Expertises.Any(x => x.Expertise == expertise && x.ExpertiseLevel.Level >= expertiseLevel.Level))
            {
                return true;
            }
            return false;
        }

        public bool HasLanguage(Language language, LanguageLevel languageLevel)
        {
            if(Languages.Any(x => x.Language == language && x.LanguageLevel.Level >= (languageLevel != null? languageLevel.Level : 0)))
            {
                return true;
            }
            return false;
        }
    }
}
