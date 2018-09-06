using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Course : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Private { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Canceled { get; set; } = false;

        public int ExpertiseId { get; set; }
        public virtual Expertise Expertise { get; set; }

        public int ExpertiseLevelId { get; set; }
        public virtual ExpertiseLevel ExpertiseLevel { get; set; }

        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int? LanguageLevelId { get; set; }
        public virtual LanguageLevel LanguageLevel { get; set; }

        public int RentalId { get; set; }
        public virtual Rental Rental { get; set; }

        public int RentalPlaceId { get; set; }
        public virtual RentalPlace RentalPlace { get; set; }

        private ICollection<InstructorCourse> instructors;
        public virtual ICollection<InstructorCourse> Instructors
        {
            get { return instructors ?? (instructors = new HashSet<InstructorCourse>()); }
            set { instructors = value; }
        }
    }
}
