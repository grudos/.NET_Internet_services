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

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Athlete>>> GetAthletes()
        {
            return await _context.Athletes.ToListAsync();
        }

        [HttpGet("{id}")]
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
    }
}
