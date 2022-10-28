using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsAgents.Models;

namespace SportsAgents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthletesController : ControllerBase
    {
        private readonly SportsAgentsContext _context;

        public AthletesController(SportsAgentsContext context)
        {
            _context = context;
        }

        [HttpGet("GetAthletes")]
        public async Task<ActionResult<IEnumerable<Athlete>>> GetAthletes()
        {
            return await _context.Athletes.ToListAsync();
        }

        [HttpGet("GetAthlete/{id}")]
        public ActionResult<Athlete> GetAthlete(int id)
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

        [HttpPut("PutAthlete/{id}")]
        public async Task<IActionResult> PutAthlete(int id, [FromBody]Athlete athlete)
        {
            if (id != athlete.Id)
            {
                return BadRequest();
            }

            _context.Entry(athlete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("PostAthlete")]
        public async Task<ActionResult<Athlete>> PostAthlete(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAthlete", new { id = athlete.Id }, athlete);
        }

        [HttpDelete("DeleteAthlete/{id}")]
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

        private bool AthleteExists(int id)
        {
            return _context.Athletes.Any(e => e.Id == id);
        }
    }
}
