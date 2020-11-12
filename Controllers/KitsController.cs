using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hort_Ed.Models;

namespace Hort_Ed.Controllers
{
    public class KitsController : Controller
    {
        private readonly Hort_EdContext _context;

        public KitsController(Hort_EdContext context)
        {
            _context = context;
        }

        // GET: Kits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kits.ToListAsync());
        }

        // GET: Kits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kits = await _context.Kits
                .FirstOrDefaultAsync(m => m.KitId == id);
            if (kits == null)
            {
                return NotFound();
            }

            return View(kits);
        }

        // GET: Kits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitId,KitName,Cost,Details")] Kits kits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kits);
        }

        // GET: Kits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kits = await _context.Kits.FindAsync(id);
            if (kits == null)
            {
                return NotFound();
            }
            return View(kits);
        }

        // POST: Kits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitId,KitName,Cost,Details")] Kits kits)
        {
            if (id != kits.KitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitsExists(kits.KitId))
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
            return View(kits);
        }

        // GET: Kits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kits = await _context.Kits
                .FirstOrDefaultAsync(m => m.KitId == id);
            if (kits == null)
            {
                return NotFound();
            }

            return View(kits);
        }

        // POST: Kits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kits = await _context.Kits.FindAsync(id);
            _context.Kits.Remove(kits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitsExists(int id)
        {
            return _context.Kits.Any(e => e.KitId == id);
        }
    }
}
