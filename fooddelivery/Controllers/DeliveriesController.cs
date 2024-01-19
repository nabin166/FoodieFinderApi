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
    public class DeliveriesController : ControllerBase
    {
        private readonly foodcontext _context;

        public DeliveriesController(foodcontext context)
        {
            _context = context;
        }

        // GET: api/Deliveries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deliveries>>> GetDeliveries()
        {
          if (_context.Deliveries == null)
          {
              return NotFound();
          }
            return await _context.Deliveries.ToListAsync();
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deliveries>> GetDeliveries(int id)
        {
          if (_context.Deliveries == null)
          {
              return NotFound();
          }
            var deliveries = await _context.Deliveries.FindAsync(id);

            if (deliveries == null)
            {
                return NotFound();
            }

            return deliveries;
        }

        // PUT: api/Deliveries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveries(int id, Deliveries deliveries)
        {
            if (id != deliveries.Delivery_Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveriesExists(id))
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

        // POST: api/Deliveries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deliveries>> PostDeliveries(Deliveries deliveries)
        {
          if (_context.Deliveries == null)
          {
              return Problem("Entity set 'foodcontext.Deliveries'  is null.");
          }
            _context.Deliveries.Add(deliveries);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveries", new { id = deliveries.Delivery_Id }, deliveries);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveries(int id)
        {
            if (_context.Deliveries == null)
            {
                return NotFound();
            }
            var deliveries = await _context.Deliveries.FindAsync(id);
            if (deliveries == null)
            {
                return NotFound();
            }

            _context.Deliveries.Remove(deliveries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveriesExists(int id)
        {
            return (_context.Deliveries?.Any(e => e.Delivery_Id == id)).GetValueOrDefault();
        }
    }
}
