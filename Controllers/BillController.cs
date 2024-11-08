using HMS_Project.Data;
using HMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BillController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: api/bills

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {

            return await context.Bills.Include(b => b.Patient).ToListAsync();

        }


        // GET: api/bills/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBill(int id)

        {

            var bill = await context.Bills.FindAsync(id);

            if (bill == null)

            {

                return NotFound();

            }

            return bill;

        }


        // POST: api/bills

        [HttpPost]

        public async Task<ActionResult<Bill>> PostBill(Bill bill)
        {

            context.Bills.Add(bill);

            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBill), new { id = bill.BillId }, bill);

        }


        // PUT: api/bills/5

        [HttpPut("{id}")]

        public async Task<IActionResult> PutBill(int id, Bill bill)

        {

            if (id != bill.BillId)
            {
                return BadRequest();
            }


            context.Entry(bill).State = EntityState.Modified;
            try

            {

                await context.SaveChangesAsync();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!BillExists(id))

                {

                    return NotFound();

                }

                throw;

            }


            return NoContent();

        }


        // DELETE: api/bills/5

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBill(int id)
        {

            var bill = await context.Bills.FindAsync(id);

            if (bill == null)

            {
                return NotFound();
            }


            context.Bills.Remove(bill);

            await context.SaveChangesAsync();


            return NoContent();

        }
        private bool BillExists(int id)
        {

            return context.Bills.Any(e => e.BillId == id);

        }
    }
}
