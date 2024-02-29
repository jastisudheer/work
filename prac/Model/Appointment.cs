namespace prac.Models
{
    public class Appointment
    {
        public int Id { get; set; } // Assuming there's an Id field as a primary key.
        public int PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; } // Assuming storage as a TimeSpan.
        public string Description { get; set; }
    }
}