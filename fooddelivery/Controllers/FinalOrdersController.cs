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
    public class FinalOrdersController : ControllerBase
    {
        private readonly foodcontext _context;

        public FinalOrdersController(foodcontext context)
        {
            _context = context;
        }

        // GET: api/FinalOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinalOrders>>> GetFinalOrders()
        {
          if (_context.FinalOrders == null)
          {
              return NotFound();
          }
            return await _context.FinalOrders.ToListAsync();
        }

        // GET: api/FinalOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinalOrders>> GetFinalOrders(int id)
        {
          if (_context.FinalOrders == null)
          {
              return NotFound();
          }
            var finalOrders = await _context.FinalOrders.FindAsync(id);

            if (finalOrders == null)
            {
                return NotFound();
            }

            return finalOrders;
        }

        // PUT: api/FinalOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinalOrders(int id, FinalOrders finalOrders)
        {
            if (id != finalOrders.FinalOrder_Id)
            {
                return BadRequest();
            }

            _context.Entry(finalOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalOrdersExists(id))
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

        // POST: api/FinalOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinalOrders>> PostFinalOrders(FinalOrders finalOrders)
        {
          if (_context.FinalOrders == null)
          {
              return Problem("Entity set 'foodcontext.FinalOrders'  is null.");
          }
            _context.FinalOrders.Add(finalOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinalOrders", new { id = finalOrders.FinalOrder_Id }, finalOrders);
        }

        // DELETE: api/FinalOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinalOrders(int id)
        {
            if (_context.FinalOrders == null)
            {
                return NotFound();
            }
            var finalOrders = await _context.FinalOrders.FindAsync(id);
            if (finalOrders == null)
            {
                return NotFound();
            }

            _context.FinalOrders.Remove(finalOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinalOrdersExists(int id)
        {
            return (_context.FinalOrders?.Any(e => e.FinalOrder_Id == id)).GetValueOrDefault();
        }
    }
}
