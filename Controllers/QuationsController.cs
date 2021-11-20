using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Q_A_system.Models;

namespace Q_A_system.Controllers
{
    public class QuationsController : Controller
    {
        private readonly AppDbContext _context;

        public QuationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Quations
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Quations.Include(q => q.ApplicationUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Quations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quation = await _context.Quations
                .Include(q => q.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quation == null)
            {
                return NotFound();
            }

            return View(quation);
        }

        // GET: Qu
        // ations/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Quations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qtype,Qname,ApplicationUserId")] Quation quation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", quation.ApplicationUserId);
            return View();
        }

        // GET: Quations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quation = await _context.Quations.FindAsync(id);
            if (quation == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", quation.ApplicationUserId);
            return View(quation);
        }

        // POST: Quations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qtype,Qname,ApplicationUserId")] Quation quation)
        {
            if (id != quation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuationExists(quation.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", quation.ApplicationUserId);
            return View(quation);
        }

        // GET: Quations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quation = await _context.Quations
                .Include(q => q.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quation == null)
            {
                return NotFound();
            }

            return View(quation);
        }

        // POST: Quations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quation = await _context.Quations.FindAsync(id);
            _context.Quations.Remove(quation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuationExists(int id)
        {
            return _context.Quations.Any(e => e.Id == id);
        }
    }
}
