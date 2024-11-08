using HMS_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HMS_Project.Data
{
    public class ApplicationDbContext:DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }    
        
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DashBoard> DashBoards { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
