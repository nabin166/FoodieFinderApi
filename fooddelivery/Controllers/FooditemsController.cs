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
    public class FooditemsController : ControllerBase
    {
        private readonly foodcontext _context;

        public FooditemsController(foodcontext context)
        {
            _context = context;
        }

        // GET: api/Fooditems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fooditems>>> GetFoodItems()
        {
          if (_context.FoodItems == null)
          {
              return NotFound();
          }
            return await _context.FoodItems.ToListAsync();
        }

        // GET: api/Fooditems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fooditems>> GetFooditems(int id)
        {
          if (_context.FoodItems == null)
          {
              return NotFound();
          }
            var fooditems = await _context.FoodItems.FindAsync(id);

            if (fooditems == null)
            {
                return NotFound();
            }

            return fooditems;
        }

        // PUT: api/Fooditems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooditems(int id, Fooditems fooditems)
        {
            if (id != fooditems.Fooditem_id)
            {
                return BadRequest();
            }

            _context.Entry(fooditems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FooditemsExists(id))
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

        // POST: api/Fooditems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fooditems>> PostFooditems(Fooditems fooditems)
        {
          if (_context.FoodItems == null)
          {
              return Problem("Entity set 'foodcontext.FoodItems'  is null.");
          }
            _context.FoodItems.Add(fooditems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFooditems", new { id = fooditems.Fooditem_id }, fooditems);
        }

        // DELETE: api/Fooditems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooditems(int id)
        {
            if (_context.FoodItems == null)
            {
                return NotFound();
            }
            var fooditems = await _context.FoodItems.FindAsync(id);
            if (fooditems == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(fooditems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FooditemsExists(int id)
        {
            return (_context.FoodItems?.Any(e => e.Fooditem_id == id)).GetValueOrDefault();
        }
    }
}
