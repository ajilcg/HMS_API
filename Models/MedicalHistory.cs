namespace Hospital_management.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public string? MedicalDetails { get; set; }

        public string? UpdatedDate { get; set; }
        public int patientId { get; set; }
    }
}
