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
    public class WXUserOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WXUserOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WXUserOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.WXUserOrder.ToListAsync());
        }

        // GET: WXUserOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrder = await _context.WXUserOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUserOrder == null)
            {
                return NotFound();
            }

            return View(wXUserOrder);
        }

        // GET: WXUserOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WXUserOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WXUserOrderID,WXUserPhone,WXProductID,WXProductNumber")] WXUserOrder wXUserOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wXUserOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wXUserOrder);
        }

        // GET: WXUserOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrder = await _context.WXUserOrder.FindAsync(id);
            if (wXUserOrder == null)
            {
                return NotFound();
            }
            return View(wXUserOrder);
        }

        // POST: WXUserOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WXUserOrderID,WXUserPhone,WXProductID,WXProductNumber")] WXUserOrder wXUserOrder)
        {
            if (id != wXUserOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wXUserOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WXUserOrderExists(wXUserOrder.ID))
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
            return View(wXUserOrder);
        }

        // GET: WXUserOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrder = await _context.WXUserOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUserOrder == null)
            {
                return NotFound();
            }

            return View(wXUserOrder);
        }

        // POST: WXUserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wXUserOrder = await _context.WXUserOrder.FindAsync(id);
            _context.WXUserOrder.Remove(wXUserOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WXUserOrderExists(int id)
        {
            return _context.WXUserOrder.Any(e => e.ID == id);
        }
    }
}
