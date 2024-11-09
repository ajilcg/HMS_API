using HMS_Project.Data;
using HMS_Project.Models;
 using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Login(User user)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);
        if (existingUser != null)
        {
            return existingUser;
        }
        else
        {
            return NotFound();
        }
    }

   
    [HttpPost("Register")]
    public ActionResult<User> Register(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }
}

