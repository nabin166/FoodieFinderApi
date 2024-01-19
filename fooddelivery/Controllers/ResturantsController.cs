using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fooddelivery.Model;

namespace fooddelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {
        private readonly foodcontext _context;

        public ResturantsController(foodcontext context)
        {
            _context = context;
        }

        // GET: api/Resturants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resturants>>> GetResturants()
        {
          if (_context.Resturants == null)
          {
              return NotFound();
          }
            return await _context.Resturants.ToListAsync();
        }

        // GET: api/Resturants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resturants>> GetResturants(int id)
        {
          if (_context.Resturants == null)
          {
              return NotFound();
          }
            var resturants = await _context.Resturants.FindAsync(id);

            if (resturants == null)
            {
                return NotFound();
            }

            return resturants;
        }

        // PUT: api/Resturants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResturants(int id, Resturants resturants)
        {
            if (id != resturants.Resturant_Id)
            {
                return BadRequest();
            }

            _context.Entry(resturants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturantsExists(id))
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

        // POST: api/Resturants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resturants>> PostResturants(Resturants resturants)
        {
          if (_context.Resturants == null)
          {
              return Problem("Entity set 'foodcontext.Resturants'  is null.");
          }
            _context.Resturants.Add(resturants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResturants", new { id = resturants.Resturant_Id }, resturants);
        }

        // DELETE: api/Resturants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturants(int id)
        {
            if (_context.Resturants == null)
            {
                return NotFound();
            }
            var resturants = await _context.Resturants.FindAsync(id);
            if (resturants == null)
            {
                return NotFound();
            }

            _context.Resturants.Remove(resturants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResturantsExists(int id)
        {
            return (_context.Resturants?.Any(e => e.Resturant_Id == id)).GetValueOrDefault();
        }
    }
}
