namespace HMS_Project.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Place { get; set; }
        public string Gender { get; set; }

        public string DoctorName { get; set; }
        public string AppointmentDate { get; set; }
        public string Department { get; set; }
    }
}
