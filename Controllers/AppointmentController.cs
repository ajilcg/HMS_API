using HMS_Project.Data;
using HMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        
        
        private readonly ApplicationDbContext context;

        

        public AppointmentController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/appointments



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetPatients()
        {
            return await context.Appointments.ToListAsync();
        }
        //[HttpGet]

        //public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        //{

        //    return await context.Appointments.Include(a => a.PatientId).Include(a => a.DoctorId).ToListAsync();

        //}


        // GET: api/appointments/5

        [HttpGet("{id}")]

        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {

            var appointment = await context.Appointments.FindAsync(id);

            if (appointment == null)

            {

                return NotFound();

            }

            return appointment;

        }


        // POST: api/appointments

        [HttpPost]

        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {

            context.Appointments.Add(appointment);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);

        }


        // PUT: api/appointments/5

        [HttpPut("{id}")]

        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)

        {

            if (id != appointment.Id)
            {
                return BadRequest();
            }


            context.Entry(appointment).State = EntityState.Modified;
            try

            {

                await context.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!AppointmentExists(id))

                {

                    return NotFound();

                }

                throw;

            }


            return NoContent();

        }


        // DELETE: api/appointments/5

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAppointment(int id)
        {

            var appointment = await context.Appointments.FindAsync(id);

            if (appointment == null)

            {
                return NotFound();
            }
            context.Appointments.Remove(appointment);

            await context.SaveChangesAsync();


            return NoContent();

        }


        private bool AppointmentExists(int id)
        {

            return context.Appointments.Any(e => e.Id == id);

        }
    }
}

