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
    public class EnrollmentsController : Controller
    {
        private readonly Hort_EdContext _context;

        public EnrollmentsController(Hort_EdContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var hort_EdContext = _context.Enrollments.Include(e => e.Customer).Include(e => e.Kit).Include(e => e.Seminar);
            return View(await hort_EdContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .Include(e => e.Customer)
                .Include(e => e.Kit)
                .Include(e => e.Seminar)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["KitSelection"] = new SelectList(_context.Enrollments, "KitSelection", "KitSelection");
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Create([Bind("EnrollmentId,CustomerId,SeminarId,KitSelection,EnrollmentDate,Notes")] Enrollments enrollments)
        {
            if (ModelState.IsValid)
            {
                enrollments.EnrollmentDate = DateTime.Now;
                _context.Add(enrollments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", enrollments.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Enrollments, "KitSelection", "KitSelection", enrollments.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", enrollments.SeminarId);
            return View(enrollments);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments.FindAsync(id);
            if (enrollments == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", enrollments.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Enrollments, "KitSelection", "KitSelection", enrollments.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", enrollments.SeminarId);
            return View(enrollments);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CustomerId,SeminarId,KitSelection,EnrollmentDate,Notes")] Enrollments enrollments)
        {
            if (id != enrollments.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentsExists(enrollments.EnrollmentId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", enrollments.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Enrollments, "KitSelection", "KitSelection", enrollments.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", enrollments.SeminarId);
            return View(enrollments);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollments = await _context.Enrollments
                .Include(e => e.Customer)
                .Include(e => e.Kit)
                .Include(e => e.Seminar)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollments == null)
            {
                return NotFound();
            }

            return View(enrollments);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollments = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentsExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentId == id);
        }
    }
}
