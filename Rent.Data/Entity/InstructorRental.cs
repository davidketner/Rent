namespace Rent.Data.Entity
{
    public class InstructorRental
    {
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
        public int RentalId { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
