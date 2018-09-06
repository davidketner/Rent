using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorExpertise
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int ExpertiseId { get; set; }
        public virtual Expertise Expertise { get; set; }
        public int ExpertiseLevelId { get; set; }
        public virtual ExpertiseLevel ExpertiseLevel { get; set; }
    }
}
