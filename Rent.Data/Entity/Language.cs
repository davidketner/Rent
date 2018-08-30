using System;
using System.Collections.Generic;
using System.Text;
using UtilityLibrary;

namespace Rent.Data.Entity
{
    public class Language : BaseEntity<int>, ISoftDeletable
    {
        public string Shortname { get; set; }
        public string Name { get; set; }
        public string Lang { get; set; }
        public bool Localized { get; set; } = false;

        public virtual ICollection<InstructorLanguage> Instructors { get; set; }
    }
}
