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
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int EmergancyContactNumber { get; set; }
        public string MedicalHistory { get; set; }
    }
}
