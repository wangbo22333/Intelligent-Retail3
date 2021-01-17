using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;

namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WXUserOrderAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WXUserOrderAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXUserOrderAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WXUserOrder>>> GetWXUserOrder()
        {
            return await _context.WXUserOrder.ToListAsync();
        }

        // GET: api/WXUserOrderAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WXUserOrder>> GetWXUserOrder(int id)
        {
            var wXUserOrder = await _context.WXUserOrder.FindAsync(id);

            if (wXUserOrder == null)
            {
                return NotFound();
            }

            return wXUserOrder;
        }

        // PUT: api/WXUserOrderAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWXUserOrder(int id, WXUserOrder wXUserOrder)
        {
            if (id != wXUserOrder.ID)
            {
                return BadRequest();
            }

            _context.Entry(wXUserOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WXUserOrderExists(id))
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

        // POST: api/WXUserOrderAPI
        [HttpPost]
        public async Task<ActionResult<WXUserOrder>> PostWXUserOrder(WXUserOrder wXUserOrder)
        {
            _context.WXUserOrder.Add(wXUserOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWXUserOrder", new { id = wXUserOrder.ID }, wXUserOrder);
        }

        // DELETE: api/WXUserOrderAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WXUserOrder>> DeleteWXUserOrder(int id)
        {
            var wXUserOrder = await _context.WXUserOrder.FindAsync(id);
            if (wXUserOrder == null)
            {
                return NotFound();
            }

            _context.WXUserOrder.Remove(wXUserOrder);
            await _context.SaveChangesAsync();

            return wXUserOrder;
        }

        private bool WXUserOrderExists(int id)
        {
            return _context.WXUserOrder.Any(e => e.ID == id);
        }
    }
}
