using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;

namespace Intelligent_Retail3.Controllers
{
    public class WXUserOrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WXUserOrderDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WXUserOrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WXUserOrderDetail.ToListAsync());
        }

        // GET: WXUserOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrderDetail = await _context.WXUserOrderDetail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUserOrderDetail == null)
            {
                return NotFound();
            }

            return View(wXUserOrderDetail);
        }

        // GET: WXUserOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WXUserOrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,WXUserOrderID,WXUserPhone,WXProductID,WXProductNumber")] WXUserOrderDetail wXUserOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wXUserOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wXUserOrderDetail);
        }

        // GET: WXUserOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrderDetail = await _context.WXUserOrderDetail.FindAsync(id);
            if (wXUserOrderDetail == null)
            {
                return NotFound();
            }
            return View(wXUserOrderDetail);
        }

        // POST: WXUserOrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,WXUserOrderID,WXUserPhone,WXProductID,WXProductNumber")] WXUserOrderDetail wXUserOrderDetail)
        {
            if (id != wXUserOrderDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wXUserOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WXUserOrderDetailExists(wXUserOrderDetail.ID))
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
            return View(wXUserOrderDetail);
        }

        // GET: WXUserOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wXUserOrderDetail = await _context.WXUserOrderDetail
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wXUserOrderDetail == null)
            {
                return NotFound();
            }

            return View(wXUserOrderDetail);
        }

        // POST: WXUserOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wXUserOrderDetail = await _context.WXUserOrderDetail.FindAsync(id);
            _context.WXUserOrderDetail.Remove(wXUserOrderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WXUserOrderDetailExists(int id)
        {
            return _context.WXUserOrderDetail.Any(e => e.ID == id);
        }
    }
}
