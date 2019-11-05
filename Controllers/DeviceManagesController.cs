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
    public class DeviceManagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceManagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeviceManages
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeviceManage.ToListAsync());
        }

        // GET: DeviceManages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceManage = await _context.DeviceManage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deviceManage == null)
            {
                return NotFound();
            }

            return View(deviceManage);
        }

        // GET: DeviceManages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeviceManages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DeviceID,DeviceNumber,DeviceProductKey,DeviceSecret,DeviceProvince,DeviceCity,DeviceAddress,DeviceSetDay")] DeviceManage deviceManage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceManage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deviceManage);
        }

        // GET: DeviceManages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceManage = await _context.DeviceManage.FindAsync(id);
            if (deviceManage == null)
            {
                return NotFound();
            }
            return View(deviceManage);
        }

        // POST: DeviceManages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DeviceID,DeviceNumber,DeviceProductKey,DeviceSecret,DeviceProvince,DeviceCity,DeviceAddress,DeviceSetDay")] DeviceManage deviceManage)
        {
            if (id != deviceManage.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceManage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceManageExists(deviceManage.ID))
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
            return View(deviceManage);
        }

        // GET: DeviceManages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceManage = await _context.DeviceManage
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deviceManage == null)
            {
                return NotFound();
            }

            return View(deviceManage);
        }

        // POST: DeviceManages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceManage = await _context.DeviceManage.FindAsync(id);
            _context.DeviceManage.Remove(deviceManage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceManageExists(int id)
        {
            return _context.DeviceManage.Any(e => e.ID == id);
        }
    }
}
