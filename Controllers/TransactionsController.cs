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
    public class TransactionsController : Controller
    {
        private readonly Hort_EdContext _context;

        public TransactionsController(Hort_EdContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var hort_EdContext = _context.Transactions.Include(t => t.Customer).Include(t => t.Kit).Include(t => t.Seminar);
            return View(await hort_EdContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Include(t => t.Kit)
                .Include(t => t.Seminar)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["KitSelection"] = new SelectList(_context.Kits, "KitSelection", "KitSelection");
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,CustomerId,SeminarId,KitSelection,ChangeDate,ChangeAction")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", transactions.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Kits, "KitSelection", "KitSelection", transactions.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", transactions.SeminarId);
            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", transactions.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Kits, "KitSelection", "KitSelection", transactions.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", transactions.SeminarId);
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,CustomerId,SeminarId,KitSelection,ChangeDate,ChangeAction")] Transactions transactions)
        {
            if (id != transactions.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionsExists(transactions.TransactionId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", transactions.CustomerId);
            ViewData["KitSelection"] = new SelectList(_context.Kits, "KitSelection", "KitSelection", transactions.KitSelection);
            ViewData["SeminarId"] = new SelectList(_context.Seminars, "SeminarId", "SeminarId", transactions.SeminarId);
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactions
                .Include(t => t.Customer)
                .Include(t => t.Kit)
                .Include(t => t.Seminar)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
