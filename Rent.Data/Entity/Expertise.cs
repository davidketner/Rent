using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Expertise : BaseEntity<int>, ISoftDeletable
    {
        public string Shortname { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<InstructorExpertise> Instructors { get; set; }
    }
}
