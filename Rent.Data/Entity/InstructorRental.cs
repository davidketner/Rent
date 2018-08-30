namespace Rent.Data.Entity
{
    public class InstructorRental
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
