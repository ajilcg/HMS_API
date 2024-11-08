using HMS_Project.Data;
using HMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DoctorController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            return await context.Doctors.ToListAsync();
        }
        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }
        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            context.Entry(doctor).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }
        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            context.Doctors.Remove(doctor);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

