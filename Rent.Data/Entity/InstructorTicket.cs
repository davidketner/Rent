using System;
using System.Collections.Generic;
using System.Text;

namespace Rent.Data.Entity
{
    public class InstructorTicket
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
