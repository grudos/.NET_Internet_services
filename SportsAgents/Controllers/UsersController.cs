using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SportsAgents.Models;

namespace SportsAgents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SportsAgentsContext _context;

        public UsersController(SportsAgentsContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("GetUserByLogin/{login}")]
        public ActionResult<User> GetUser(string login)
        {
            var user = _context.Users
                .Include(u => u.Athletes)
                .Where(u => u.Login == login)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("GetUserAthletesByLogin/{login}")]
        public ActionResult<IEnumerable<Athlete>> GetUserAthletes(string login)
        {
            var athletes = _context.Users
                .Include(u => u.Athletes)
                .Where(u => u.Login == login)
                .SelectMany(u => u.Athletes);

            if (athletes == null)
            {
                return NotFound();
            }

            return Ok(athletes);
        }

        [HttpPost("PostUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Login))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{login}")]
        public async Task<IActionResult> DeleteUser(string login)
        {
            var user = await _context.Users.FindAsync(login);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string login)
        {
            return _context.Users.Any(e => e.Login == login);
        }
    }
}
