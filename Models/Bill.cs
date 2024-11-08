namespace HMS_Project.Models
{
    public class Bill
    {
        public int BillId { get; set; }

        public int PatientId { get; set; }

        public string Treatment { get; set; }

        public string Medication { get; set; }

        public decimal TotalCost { get; set; }

        public Patient Patient { get; set; }
    }
}
