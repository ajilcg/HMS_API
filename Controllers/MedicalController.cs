using HMS_Project.Data;
using Hospital_management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MedicalController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHistory>> GetMedicalHistory(int id)
        {
            var medicalHis = context.medicals.Where(m => m.patientId == id).OrderByDescending(k=>k.Id).Select(g => g);
            if (medicalHis == null)
            {
                return NotFound();
            }
            return Ok(medicalHis);
        }

        // POST: api/Patients
        [HttpPost]
        public async Task<ActionResult<MedicalHistory>> AddMedicalHistory(MedicalHistory medicalHistory)
        {
            try
            {
                if (medicalHistory.Id==null)
                {
                    return NotFound();

                }
                else
                {
                    medicalHistory.UpdatedDate = Convert.ToString(DateTime.Now);
                    context.medicals.Add(medicalHistory);
                await context.SaveChangesAsync();

                }

            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
