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
    public class BrandCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BrandCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BrandCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrandCategory.ToListAsync());
        }

        // GET: BrandCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandCategory = await _context.BrandCategory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brandCategory == null)
            {
                return NotFound();
            }

            return View(brandCategory);
        }

        // GET: BrandCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BrandID,BrandName,BrandInfo")] BrandCategory brandCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandCategory);
        }

        // GET: BrandCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandCategory = await _context.BrandCategory.FindAsync(id);
            if (brandCategory == null)
            {
                return NotFound();
            }
            return View(brandCategory);
        }

        // POST: BrandCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BrandID,BrandName,BrandInfo")] BrandCategory brandCategory)
        {
            if (id != brandCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandCategoryExists(brandCategory.ID))
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
            return View(brandCategory);
        }

        // GET: BrandCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandCategory = await _context.BrandCategory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brandCategory == null)
            {
                return NotFound();
            }

            return View(brandCategory);
        }

        // POST: BrandCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandCategory = await _context.BrandCategory.FindAsync(id);
            _context.BrandCategory.Remove(brandCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandCategoryExists(int id)
        {
            return _context.BrandCategory.Any(e => e.ID == id);
        }
    }
}
