namespace HospitalInformationSystem.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Specialization { get; set; }
    }
}
