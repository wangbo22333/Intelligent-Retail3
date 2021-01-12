using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Intelligent_Retail3.Controllers
{
    [Authorize]
    public class WXUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WXUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WXUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.WXUser.ToListAsync());
        }

        // GET: WXUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUser = await _context.WXUser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUser == null)
            {
                return NotFound();
            }

            return View(wXUser);
        }

        // GET: WXUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WXUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WXUserNickName,WXUserOpenID,WXUserPhone,WXUserGender,WXUserBirthday")] WXUser wXUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wXUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wXUser);
        }

        // GET: WXUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUser = await _context.WXUser.FindAsync(id);
            if (wXUser == null)
            {
                return NotFound();
            }
            return View(wXUser);
        }

        // POST: WXUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WXUserNickName,WXUserOpenID,WXUserPhone,WXUserGender,WXUserBirthday")] WXUser wXUser)
        {
            if (id != wXUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wXUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WXUserExists(wXUser.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wXUser);
        }

        // GET: WXUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUser = await _context.WXUser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUser == null)
            {
                return NotFound();
            }

            return View(wXUser);
        }

        // POST: WXUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wXUser = await _context.WXUser.FindAsync(id);
            _context.WXUser.Remove(wXUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WXUserExists(int id)
        {
            return _context.WXUser.Any(e => e.ID == id);
        }
    }
}
