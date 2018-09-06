using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorCourse
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
