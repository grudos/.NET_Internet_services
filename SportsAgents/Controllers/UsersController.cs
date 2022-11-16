using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [Authorize]
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }


        [Authorize]
        [HttpGet("{login}")]
        public ActionResult<User> GetUser([FromRoute(Name = "login")] string login)
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


        [Authorize]
        [HttpGet("{login}/Athletes")]
        public ActionResult<IEnumerable<Athlete>> GetUserAthletes([FromRoute(Name = "login")] string login)
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


        [Authorize]
        [HttpGet("{login}/Athletes/{id}")]
        public ActionResult<Athlete> GetUserAthlete(int id)
        {
            var athlete = _context.Athletes
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (athlete == null)
            {
                return NotFound();
            }

            return athlete;
        }


        [Authorize]
        [HttpPut("{login}/Athletes/{id}")]
        public async Task<IActionResult> PutUserAthlete([FromRoute(Name = "login")] string login, 
            [FromRoute(Name = "id")] int id, [FromBody] Athlete athlete)
        {
            athlete.Id = id;
            athlete.UserLogin = login;

            _context.Entry(athlete).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [Authorize]
        [HttpPost("{login}/Athletes/")]
        public async Task<ActionResult<Athlete>> PostUserAthlete([FromRoute(Name = "login")] string login, Athlete athlete)
        {
            athlete.UserLogin = login;
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();

            return Ok(athlete);
        }


        [Authorize]
        [HttpDelete("{login}")]
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


        [Authorize]
        [HttpDelete("{login}/Athletes/{id}")]
        public async Task<IActionResult> DeleteAthlete(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            if (athlete == null)
            {
                return NotFound();
            }

            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
