using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_POE_TimeMangement.Data;
using Final_POE_TimeMangement.Models;
using System.Security.Claims;

namespace Final_POE_TimeMangement.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //claims new to restrict acccess to views
        private readonly IWebHostEnvironment webHostEnvironment;

        public ModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound(); // Or handle the absence of a user ID
            }

            var currentLoggedInUserModules = await _context.Module
                .Where(m => m.UserID == userId)
                .ToListAsync();

            return View(currentLoggedInUserModules);

        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }

            var modules = await _context.Module
                .FirstOrDefaultAsync(m => m.ModuleId == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleId,ModuleCode,ModuleName,ModuleCredits,ModuleClassHours,Semester,SelfStudyHours,StudyHoursLeft,UserID")] Modules modules)
        {
            if (ModelState.IsValid)
            {

                modules.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // Calculate remaining study hours
                double remainingStudyHours = WeeklyStudyHours.Class1.WeeklyStudyHours(@modules.ModuleCredits, 10, @modules.ModuleClassHours);

                // Update the StudyHoursLeft property of the module
                @modules.StudyHoursLeft = (int)remainingStudyHours;

                _context.Add(@modules);
                await _context.SaveChangesAsync();

                // Create a view model to pass data to the view
                var viewModel = new ModuleViewModel
                {
                    Module = modules,
                    remainingStudyHours = (int)remainingStudyHours
                };

                // Pass the view model to the view
                return View("DisplayHrs", viewModel);
            }

            return View(@modules);
        }


        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }

            var modules = await _context.Module.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModuleId,ModuleCode,ModuleName,ModuleCredits,ModuleClassHours,Semester,SelfStudyHours,StudyHoursLeft,UserID")] Modules modules)
        {
            if (id != modules.ModuleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulesExists(modules.ModuleId))
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
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Module == null)
            {
                return NotFound();
            }

            var modules = await _context.Module
                .FirstOrDefaultAsync(m => m.ModuleId == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Module == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Module'  is null.");
            }
            var modules = await _context.Module.FindAsync(id);
            if (modules != null)
            {
                _context.Module.Remove(modules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulesExists(int id)
        {
          return (_context.Module?.Any(e => e.ModuleId == id)).GetValueOrDefault();
        }
    }
}
