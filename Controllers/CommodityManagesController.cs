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
    [Authorize(Roles ="Admin")]
    public class CommodityManagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommodityManagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommodityManages
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommodityManage.ToListAsync());
        }

        // GET: CommodityManages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commodityManage = await _context.CommodityManage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (commodityManage == null)
            {
                return NotFound();
            }

            return View(commodityManage);
        }

        // GET: CommodityManages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommodityManages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,CategoryID,BrandID,ProductName,ProductImage,ProductWeight,ProductPrice,ProductStock,ProductSale")] CommodityManage commodityManage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commodityManage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commodityManage);
        }

        // GET: CommodityManages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commodityManage = await _context.CommodityManage.FindAsync(id);
            if (commodityManage == null)
            {
                return NotFound();
            }
            return View(commodityManage);
        }

        // POST: CommodityManages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,CategoryID,BrandID,ProductName,ProductImage,ProductWeight,ProductPrice,ProductStock,ProductSale")] CommodityManage commodityManage)
        {
            if (id != commodityManage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commodityManage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommodityManageExists(commodityManage.ID))
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
            return View(commodityManage);
        }

        // GET: CommodityManages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commodityManage = await _context.CommodityManage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (commodityManage == null)
            {
                return NotFound();
            }

            return View(commodityManage);
        }

        // POST: CommodityManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commodityManage = await _context.CommodityManage.FindAsync(id);
            _context.CommodityManage.Remove(commodityManage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommodityManageExists(int id)
        {
            return _context.CommodityManage.Any(e => e.ID == id);
        }
    }
}
