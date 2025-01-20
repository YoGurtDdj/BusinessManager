using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestPO.Models;

namespace TestPO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var user1 = _context.Users.FirstOrDefault(u => u.Username == user.Username);
            if (user1 == null || user.Password != user1.Password)
            {
                return BadRequest("Invalid username or password.");
            }
            else
            {
                return Ok(new { message = "Login successful!", userId = user.UserId });
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest("Username is already taken.");


            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                // Возвращаем информацию об ошибке в формате JSON
                return StatusCode(500, new { error = "An error occurred while registering the user.", details = ex.Message });
            }
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
