using HMS_Project.Data;
using HMS_Project.Models;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext context;
        public PatientController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }


        // POST: api/Patients
        [HttpPost]

        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            try
            {
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
                MedicalHistory history = new MedicalHistory();
                history.patientId = patient.Id;
                history.UpdatedDate = Convert.ToString(DateTime.Now);
                history.MedicalDetails = patient.MedicalHistory;
                context.medicals.Add(history);
                await context.SaveChangesAsync();

                return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);


            }
            catch (Exception)
            {

                throw;
            }

        }


        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            context.Entry(patient).State = EntityState.Modified;

            MedicalHistory history = new MedicalHistory();
            var dat = context.medicals.FirstOrDefault(d => d.Id == id);
            if (dat == null)
            {
                return NotFound();

            }
            dat.MedicalDetails = patient.MedicalHistory;
            context.medicals.Update(dat);
            context.SaveChanges();

            return NoContent();
        }
        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            context.Patients.Remove(patient);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }

}

