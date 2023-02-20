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
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
              return _context.GangMembers != null ? 
                          View(await _context.GangMembers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.GangMembers'  is null.");
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember = await _context.GangMembers
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (gangMember == null)
            {
                return NotFound();
            }

            return View(gangMember);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,FirstName,LastName,Nationality,Strength,Endurance,Intelligence,Luck")] GangMember gangMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gangMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gangMember);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember = await _context.GangMembers.FindAsync(id);
            if (gangMember == null)
            {
                return NotFound();
            }
            return View(gangMember);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,FirstName,LastName,Nationality,Strength,Endurance,Intelligence,Luck")] GangMember gangMember)
        {
            if (id != gangMember.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gangMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GangMemberExists(gangMember.MemberId))
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
            return View(gangMember);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GangMembers == null)
            {
                return NotFound();
            }

            var gangMember = await _context.GangMembers
                .FirstOrDefaultAsync(m => m.MemberId == id);
            if (gangMember == null)
            {
                return NotFound();
            }

            return View(gangMember);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GangMembers == null)
            {
                return Problem("Entity set 'AppDbContext.GangMembers'  is null.");
            }
            var gangMember = await _context.GangMembers.FindAsync(id);
            if (gangMember != null)
            {
                _context.GangMembers.Remove(gangMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GangMemberExists(int id)
        {
          return (_context.GangMembers?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
