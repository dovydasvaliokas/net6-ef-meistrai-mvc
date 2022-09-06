using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using meistrai_mvc_mano.Data;
using meistrai_mvc_mano.Models;

namespace meistrai_mvc_mano.Controllers
{
    public class AutoServicesController : Controller
    {
        private readonly meistrai_mvc_manoContext _context;

        public AutoServicesController(meistrai_mvc_manoContext context)
        {
            _context = context;
        }

        // GET: AutoServices
        public async Task<IActionResult> Index()
        {
              return _context.AutoService != null ? 
                          View(await _context.AutoService.ToListAsync()) :
                          Problem("Entity set 'meistrai_mvc_manoContext.AutoService'  is null.");
        }

        // GET: AutoServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AutoService == null)
            {
                return NotFound();
            }

            var autoService = await _context.AutoService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoService == null)
            {
                return NotFound();
            }

            return View(autoService);
        }

        // GET: AutoServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manager,Address")] AutoService autoService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoService);
        }

        // GET: AutoServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AutoService == null)
            {
                return NotFound();
            }

            var autoService = await _context.AutoService.FindAsync(id);
            if (autoService == null)
            {
                return NotFound();
            }
            return View(autoService);
        }

        // POST: AutoServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manager,Address")] AutoService autoService)
        {
            if (id != autoService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoServiceExists(autoService.Id))
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
            return View(autoService);
        }

        // GET: AutoServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AutoService == null)
            {
                return NotFound();
            }

            var autoService = await _context.AutoService
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoService == null)
            {
                return NotFound();
            }

            return View(autoService);
        }

        // POST: AutoServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AutoService == null)
            {
                return Problem("Entity set 'meistrai_mvc_manoContext.AutoService'  is null.");
            }
            var autoService = await _context.AutoService.FindAsync(id);
            if (autoService != null)
            {
                _context.AutoService.Remove(autoService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoServiceExists(int id)
        {
          return (_context.AutoService?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
