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
    public class SeminarsController : Controller
    {
        private readonly Hort_EdContext _context;

        public SeminarsController(Hort_EdContext context)
        {
            _context = context;
        }

        // GET: Seminars
        public async Task<IActionResult> Index()
        {
            var hort_EdContext = _context.Seminars.Include(s => s.MaterialKit1Navigation).Include(s => s.MaterialKit2Navigation).Include(s => s.MaterialKit3Navigation);
            return View(await hort_EdContext.ToListAsync());
        }

        // GET: Seminars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminars = await _context.Seminars
                .Include(s => s.MaterialKit1Navigation)
                .Include(s => s.MaterialKit2Navigation)
                .Include(s => s.MaterialKit3Navigation)
                .FirstOrDefaultAsync(m => m.SeminarId == id);
            if (seminars == null)
            {
                return NotFound();
            }

            return View(seminars);
        }

        // GET: Seminars/Create
        public IActionResult Create()
        {
            ViewData["MaterialKit1"] = new SelectList(_context.Kits, "KitId", "KitId");
            ViewData["MaterialKit2"] = new SelectList(_context.Kits, "KitId", "KitId");
            ViewData["MaterialKit3"] = new SelectList(_context.Kits, "KitId", "KitId");
            return View();
        }

        // POST: Seminars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeminarId,SeminarTitle,Seasonal,DeliveryType,MaterialKit1,MaterialKit2,MaterialKit3,Details,EventDate")] Seminars seminars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seminars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialKit1"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit1);
            ViewData["MaterialKit2"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit2);
            ViewData["MaterialKit3"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit3);
            return View(seminars);
        }

        // GET: Seminars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminars = await _context.Seminars.FindAsync(id);
            if (seminars == null)
            {
                return NotFound();
            }
            ViewData["MaterialKit1"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit1);
            ViewData["MaterialKit2"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit2);
            ViewData["MaterialKit3"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit3);
            return View(seminars);
        }

        // POST: Seminars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SeminarId,SeminarTitle,Seasonal,DeliveryType,MaterialKit1,MaterialKit2,MaterialKit3,Details,EventDate")] Seminars seminars)
        {
            if (id != seminars.SeminarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seminars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeminarsExists(seminars.SeminarId))
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
            ViewData["MaterialKit1"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit1);
            ViewData["MaterialKit2"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit2);
            ViewData["MaterialKit3"] = new SelectList(_context.Kits, "KitId", "KitId", seminars.MaterialKit3);
            return View(seminars);
        }

        // GET: Seminars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminars = await _context.Seminars
                .Include(s => s.MaterialKit1Navigation)
                .Include(s => s.MaterialKit2Navigation)
                .Include(s => s.MaterialKit3Navigation)
                .FirstOrDefaultAsync(m => m.SeminarId == id);
            if (seminars == null)
            {
                return NotFound();
            }

            return View(seminars);
        }

        // POST: Seminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var seminars = await _context.Seminars.FindAsync(id);
            _context.Seminars.Remove(seminars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeminarsExists(string id)
        {
            return _context.Seminars.Any(e => e.SeminarId == id);
        }
    }
}
