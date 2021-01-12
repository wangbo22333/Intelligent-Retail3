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
    public class DeviceProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceProduct.ToListAsync());
        }

        // GET: DeviceProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProduct = await _context.DeviceProduct
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deviceProduct == null)
            {
                return NotFound();
            }

            return View(deviceProduct);
        }

        // GET: DeviceProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DeviceID,ProductID,DeviceProductStock,DeviceProductSale")] DeviceProduct deviceProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceProduct);
        }

        // GET: DeviceProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProduct = await _context.DeviceProduct.FindAsync(id);
            if (deviceProduct == null)
            {
                return NotFound();
            }
            return View(deviceProduct);
        }

        // POST: DeviceProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DeviceID,ProductID,DeviceProductStock,DeviceProductSale")] DeviceProduct deviceProduct)
        {
            if (id != deviceProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceProductExists(deviceProduct.ID))
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
            return View(deviceProduct);
        }

        // GET: DeviceProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceProduct = await _context.DeviceProduct
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deviceProduct == null)
            {
                return NotFound();
            }

            return View(deviceProduct);
        }

        // POST: DeviceProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceProduct = await _context.DeviceProduct.FindAsync(id);
            _context.DeviceProduct.Remove(deviceProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceProductExists(int id)
        {
            return _context.DeviceProduct.Any(e => e.ID == id);
        }
    }
}
