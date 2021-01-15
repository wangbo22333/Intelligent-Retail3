using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;
using Microsoft.AspNetCore.Cors;

namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class WXUsersAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WXUsersAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXUsersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WXUser>>> GetWXUser()
        {
            return await _context.WXUser.ToListAsync();
        }

        // GET: api/WXUsersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WXUser>> GetWXUser(int id)
        {
            var wXUser = await _context.WXUser.FindAsync(id);

            if (wXUser == null)
            {
                return NotFound();
            }

            return wXUser;
        }

        // PUT: api/WXUsersAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWXUser(string id, WXUser wXUser)
        {
            if (!id.Equals(wXUser.ID))
            {
                return BadRequest();
            }

            _context.Entry(wXUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WXUserExists(id))
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

        // POST: api/WXUsersAPI
        [HttpPost]
        public async Task<ActionResult<WXUser>> PostWXUser(WXUser wXUser)
        {
            if (WXUserExists(wXUser.WXUserOpenID))
            {
                return null;
            }else
            {
                _context.WXUser.Add(wXUser);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetWXUser", new { id = wXUser.ID }, wXUser);
            }

        }

        // DELETE: api/WXUsersAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WXUser>> DeleteWXUser(string id)
        {
            var wXUser = await _context.WXUser.FindAsync(id);
            if (wXUser == null)
            {
                return NotFound();
            }

            _context.WXUser.Remove(wXUser);
            await _context.SaveChangesAsync();

            return wXUser;
        }

        private bool WXUserExists(string id)
        {
            return _context.WXUser.Any(e => e.WXUserOpenID.Equals(id));
        }
    }
}
