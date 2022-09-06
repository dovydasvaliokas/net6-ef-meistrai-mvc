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
    public class AutoWorkersController : Controller
    {
        private readonly meistrai_mvc_manoContext _context;

        public AutoWorkersController(meistrai_mvc_manoContext context)
        {
            _context = context;
        }

        // GET: AutoWorkers
        public async Task<IActionResult> Index()
        {
              return _context.AutoWorker != null ? 
                          View(await _context.AutoWorker.ToListAsync()) :
                          Problem("Entity set 'meistrai_mvc_manoContext.AutoWorker'  is null.");
        }

        // GET: AutoWorkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AutoWorker == null)
            {
                return NotFound();
            }

            var autoWorker = await _context.AutoWorker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoWorker == null)
            {
                return NotFound();
            }

            return View(autoWorker);
        }

        // GET: AutoWorkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutoWorkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,City,Nuotrauka")] AutoWorker autoWorker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoWorker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoWorker);
        }

        // GET: AutoWorkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AutoWorker == null)
            {
                return NotFound();
            }

            var autoWorker = await _context.AutoWorker.FindAsync(id);
            if (autoWorker == null)
            {
                return NotFound();
            }
            return View(autoWorker);
        }

        // POST: AutoWorkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,City,Nuotrauka")] AutoWorker autoWorker)
        {
            if (id != autoWorker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoWorker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoWorkerExists(autoWorker.Id))
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
            return View(autoWorker);
        }

        // GET: AutoWorkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AutoWorker == null)
            {
                return NotFound();
            }

            var autoWorker = await _context.AutoWorker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoWorker == null)
            {
                return NotFound();
            }

            return View(autoWorker);
        }

        // POST: AutoWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AutoWorker == null)
            {
                return Problem("Entity set 'meistrai_mvc_manoContext.AutoWorker'  is null.");
            }
            var autoWorker = await _context.AutoWorker.FindAsync(id);
            if (autoWorker != null)
            {
                _context.AutoWorker.Remove(autoWorker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoWorkerExists(int id)
        {
          return (_context.AutoWorker?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
