using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eRandevuApp.Data;
using eRandevuApp.Models;

namespace eRandevuApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneApiController : ControllerBase
    {
        private readonly RandevuDbContext _context;

        public HastaneApiController(RandevuDbContext context)
        {
            _context = context;
        }

        // GET: api/HastaneApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hastane>>> GetSinemalar()
        {
            return await _context.Hastaneler.ToListAsync();
        }

        // GET: api/HastaneApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hastane>> GetHastane(int id)
        {
            var Hastane = await _context.Hastaneler.FindAsync(id);

            if (Hastane == null)
            {
                return NotFound();
            }

            return Hastane;
        }

        // PUT: api/HastaneApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinema(int id, Hastane Hastane)
        {
            if (id != Hastane.HastaneId)
            {
                return BadRequest();
            }

            _context.Entry(Hastane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HastaneExists(id))
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

        // POST: api/HastaneApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hastane>> PostSinema(Hastane Hastane)
        {
            _context.Hastaneler.Add(Hastane);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHastane", new { id = Hastane.HastaneId }, Hastane);
        }

        // DELETE: api/HastaneApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHastane(int id)
        {
            var Hastane = await _context.Hastaneler.FindAsync(id);
            if (Hastane == null)
            {
                return NotFound();
            }

            _context.Hastaneler.Remove(Hastane);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HastaneExists(int id)
        {
            return _context.Hastaneler.Any(e => e.HastaneId == id);
        }
    }
}
