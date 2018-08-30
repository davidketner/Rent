using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorLanguage
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int LanguageLevelId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}
