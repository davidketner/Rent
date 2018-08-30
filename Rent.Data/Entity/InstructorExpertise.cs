using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorExpertise
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }
        public int ExpertiseLevelId { get; set; }
        public ExpertiseLevel ExpertiseLevel { get; set; }
    }
}
