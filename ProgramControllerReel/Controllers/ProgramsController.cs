using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgramControllerReel.Models;

namespace ProgramControllerReel.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly ProgramControllerReelContext _context;

        public ProgramsController(ProgramControllerReelContext context)
        {
            _context = context;
        }

        // GET: Programs
        public async Task<IActionResult> Index(string searchKey)
        {
            var programs = from m in _context.Programs select m;

            if(!string.IsNullOrEmpty(searchKey))
            {
                
                programs = programs.Where(s => s.ProgramName.Contains(searchKey) || s.ProjectOwner.Contains(searchKey) || s.ProjectManager.Contains(searchKey) || s.Status.Contains(searchKey) || s.DueDate.ToShortDateString().Contains(searchKey) );
                
            }
            return View(await programs.ToListAsync());
        }

        // GET: Programs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // GET: Programs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProgramName,ProjectOwner,ProjectManager,Status,DueDate,ProjectDetails")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programs);
        }

        // GET: Programs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs.FindAsync(id);
            if (programs == null)
            {
                return NotFound();
            }
            return View(programs);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProgramName,ProjectOwner,ProjectManager,Status,DueDate,ProjectDetails")] Programs programs)
        {
            if (id != programs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramsExists(programs.Id))
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
            return View(programs);
        }

        // GET: Programs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programs = await _context.Programs.FindAsync(id);
            _context.Programs.Remove(programs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramsExists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }
}
