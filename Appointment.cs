namespace HospitalInformationSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        // Add other properties as needed
    }
}
