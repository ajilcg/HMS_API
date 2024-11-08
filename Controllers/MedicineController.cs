using HMS_Project.Data;
using HMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public MedicineController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/medicines

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicines()

        {

            return await context.Medicines.ToListAsync();

        }


        // GET: api/medicines/5

        [HttpGet("{id}")]

        public async Task<ActionResult<Medicine>> GetMedicine(int id)

        {

            var medicine = await context.Medicines.FindAsync(id);

            if (medicine == null)

            {

                return NotFound();

            }

            return medicine;

        }


        // POST: api/medicines

        [HttpPost]

        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {

            context.Medicines.Add(medicine);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedicine), new { id = medicine.MedicineId }, medicine);

        }


        // PUT: api/medicines/5

        [HttpPut("{id}")]

        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)

        {

            if (id != medicine.MedicineId)
            {
                return BadRequest();
            }


            context.Entry(medicine).State = EntityState.Modified;
            try

            {

                await context.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!MedicineExists(id))

                {

                    return NotFound();

                }

                throw;

            }


            return NoContent();

        }


        // DELETE: api/medicines/5

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMedicine(int id)
        {

            var medicine = await context.Medicines.FindAsync(id);

            if (medicine == null)

            {
                return NotFound();

            }


            context.Medicines.Remove(medicine);

            await context.SaveChangesAsync();


            return NoContent();

        }
        private bool MedicineExists(int id)
        {

            return context.Medicines.Any(e => e.MedicineId == id);

        }
    }
}

