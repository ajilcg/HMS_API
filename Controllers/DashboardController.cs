using HMS_Project.Data;
using HMS_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public DashboardController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DashBoard>>> GetDashboards()
        {
            return await context.DashBoards.ToListAsync();
        }

        [HttpGet("report")]
        public IActionResult GetReport()
        {
            var reportData = context.DashBoards
                .GroupBy(p => p.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            return Ok(reportData);
        }
    }

}

