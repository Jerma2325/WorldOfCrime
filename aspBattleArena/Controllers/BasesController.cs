using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspBattleArena.Data;
using aspBattleArena.Models;
using aspBattleArena.Views.ViewModels;

namespace aspBattleArena.Controllers
{
    public class BasesController : Controller
    {
        private readonly AppDbContext _context;

        public BasesController(AppDbContext context)
        {
            _context = context;
        }
        // private void PopulateOrganizationsDropDownList(object selectedOrganization = null)
        // {
        //     var organizationsQuery = from o in _context.Organizations
        //         orderby o.Name
        //         select o;
        //     ViewBag.DepartmentID = new SelectList(organizationsQuery, "Organization", "Name", selectedOrganization);
        // }
        // GET: Bases
        public async Task<IActionResult> Index()
        {
              return _context.Bases != null ? View(await _context.Bases.Include(or=>or.Organization).ToListAsync()) : Problem("Entity set 'AppDbContext.Bases'  is null.");
        }

        // GET: Bases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bases == null)
            {
                return NotFound();
            }

            var @base = await _context.Bases.Include(or=>or.Organization).FirstOrDefaultAsync(m => m.BaseID == id);
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
        
        public IActionResult Create([FromForm] BaseViewModel baseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    _context.Bases.Add(new Base()
                    {
                        Organization =_context.Organizations.FirstOrDefault(o=>o.Name==baseViewModel.OrganizationName), 
                        Adress = baseViewModel.Address,
                        Name = baseViewModel.Name,
                        
                    });
                     _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException /*dex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");

                
            }
            
            return View();
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
            return View();
        }

        // POST: Bases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public IActionResult Edit(int id, [FromForm] BaseViewModel baseViewModel)
        {
           
            if (ModelState.IsValid)
            {
                
                

                    _context.Bases.FirstOrDefault(b => b.BaseID == id).Name = baseViewModel.Name;
                    _context.Bases.FirstOrDefault(b => b.BaseID == id).Adress = baseViewModel.Address;
                    _context.Bases.FirstOrDefault(b => b.BaseID == id).Organization 
                        = _context.Organizations.FirstOrDefault(o=>o.Name==baseViewModel.OrganizationName);
                     _context.SaveChanges();
                
                
                return RedirectToAction(nameof(Index));
            }
            return View();
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
