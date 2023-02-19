using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspBattleArena.Data;
using aspBattleArena.Models;

namespace aspBattleArena.Controllers
{
    public class BasesController : Controller
    {
        private readonly AppDbContext _context;

        public BasesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bases
        public async Task<IActionResult> Index()
        {
              return _context.Bases != null ? 
                          View(await _context.Bases.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Bases'  is null.");
        }

        // GET: Bases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bases == null)
            {
                return NotFound();
            }

            var @base = await _context.Bases
                .FirstOrDefaultAsync(m => m.BaseID == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // GET: Bases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseID,Name,Adress")] Base @base)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@base);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@base);
        }

        // GET: Bases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bases == null)
            {
                return NotFound();
            }

            var @base = await _context.Bases.FindAsync(id);
            if (@base == null)
            {
                return NotFound();
            }
            return View(@base);
        }

        // POST: Bases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseID,Name,Adress")] Base @base)
        {
            if (id != @base.BaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@base);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseExists(@base.BaseID))
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
            return View(@base);
        }

        // GET: Bases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bases == null)
            {
                return NotFound();
            }

            var @base = await _context.Bases
                .FirstOrDefaultAsync(m => m.BaseID == id);
            if (@base == null)
            {
                return NotFound();
            }

            return View(@base);
        }

        // POST: Bases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bases == null)
            {
                return Problem("Entity set 'AppDbContext.Bases'  is null.");
            }
            var @base = await _context.Bases.FindAsync(id);
            if (@base != null)
            {
                _context.Bases.Remove(@base);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseExists(int id)
        {
          return (_context.Bases?.Any(e => e.BaseID == id)).GetValueOrDefault();
        }
    }
}
