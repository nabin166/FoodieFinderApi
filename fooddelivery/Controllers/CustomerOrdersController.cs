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
    public class CustomerOrdersController : ControllerBase
    {
        private readonly foodcontext _context;

        public CustomerOrdersController(foodcontext context)
        {
            _context = context;
        }

        // GET: api/CustomerOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerOrders>>> GetCustomerOrders()
        {
          if (_context.CustomerOrders == null)
          {
              return NotFound();
          }
            return await _context.CustomerOrders.ToListAsync();
        }

        // GET: api/CustomerOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrders>> GetCustomerOrders(int? id)
        {
          if (_context.CustomerOrders == null)
          {
              return NotFound();
          }
            var customerOrders = await _context.CustomerOrders.FindAsync(id);

            if (customerOrders == null)
            {
                return NotFound();
            }

            return customerOrders;
        }

        // PUT: api/CustomerOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerOrders(int? id, CustomerOrders customerOrders)
        {
            if (id != customerOrders.CustomerOrders_Id)
            {
                return BadRequest();
            }

            _context.Entry(customerOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOrdersExists(id))
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

        // POST: api/CustomerOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerOrders>> PostCustomerOrders(CustomerOrders customerOrders)
        {
          if (_context.CustomerOrders == null)
          {
              return Problem("Entity set 'foodcontext.CustomerOrders'  is null.");
          }
            _context.CustomerOrders.Add(customerOrders);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerOrders", new { id = customerOrders.CustomerOrders_Id }, customerOrders);
        }

        // DELETE: api/CustomerOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerOrders(int? id)
        {
            if (_context.CustomerOrders == null)
            {
                return NotFound();
            }
            var customerOrders = await _context.CustomerOrders.FindAsync(id);
            if (customerOrders == null)
            {
                return NotFound();
            }

            _context.CustomerOrders.Remove(customerOrders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerOrdersExists(int? id)
        {
            return (_context.CustomerOrders?.Any(e => e.CustomerOrders_Id == id)).GetValueOrDefault();
        }
    }
}
