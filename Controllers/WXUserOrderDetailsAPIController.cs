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
    public class WXUserOrderDetailsAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WXUserOrderDetailsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXUserOrderDetailsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WXUserOrderDetail>>> GetWXUserOrderDetail()
        {
            return await _context.WXUserOrderDetail.ToListAsync();
        }

        // GET: api/WXUserOrderDetailsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WXUserOrderDetail>> GetWXUserOrderDetail(int id)
        {
            var wXUserOrderDetail = await _context.WXUserOrderDetail.FindAsync(id);

            if (wXUserOrderDetail == null)
            {
                return NotFound();
            }

            return wXUserOrderDetail;
        }

        // PUT: api/WXUserOrderDetailsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWXUserOrderDetail(int id, WXUserOrderDetail wXUserOrderDetail)
        {
            if (id != wXUserOrderDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(wXUserOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WXUserOrderDetailExists(id))
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

        // POST: api/WXUserOrderDetailsAPI
        [HttpPost]
        public async Task<ActionResult<WXUserOrderDetail>> PostWXUserOrderDetail(WXUserOrderDetail wXUserOrderDetail)
        {
            _context.WXUserOrderDetail.Add(wXUserOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWXUserOrderDetail", new { id = wXUserOrderDetail.ID }, wXUserOrderDetail);
        }

        // DELETE: api/WXUserOrderDetailsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WXUserOrderDetail>> DeleteWXUserOrderDetail(int id)
        {
            var wXUserOrderDetail = await _context.WXUserOrderDetail.FindAsync(id);
            if (wXUserOrderDetail == null)
            {
                return NotFound();
            }

            _context.WXUserOrderDetail.Remove(wXUserOrderDetail);
            await _context.SaveChangesAsync();

            return wXUserOrderDetail;
        }

        private bool WXUserOrderDetailExists(int id)
        {
            return _context.WXUserOrderDetail.Any(e => e.ID == id);
        }
    }
}
