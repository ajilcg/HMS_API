using Hospital_management.Models;

namespace HMS_Project.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string EmergancyContactNumber { get; set; }
        public string MedicalHistory { get; set; }
        ICollection<MedicalHistory> Medical { get; set; }
    }
}
