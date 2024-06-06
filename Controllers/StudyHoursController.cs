using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_POE_TimeMangement.Data;
using Final_POE_TimeMangement.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Security.Claims;
using System.Reflection;

namespace Final_POE_TimeMangement.Controllers
{
    public class StudyHoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly INotyfService _notyf;
        //claims new to restrict acccess to views
        private readonly IWebHostEnvironment webHostEnvironment;

        public StudyHoursController(ApplicationDbContext context , INotyfService notyf)
        {
            _context = context;
            _notyf = notyf ?? throw new ArgumentNullException(nameof(notyf));
        }

        // GET: StudyHours
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound(); // Or handle the absence of a user ID
            }

            var currentLoggedInUserStudyHours = await _context.StudyHour
                .Where(m => m.UserID == userId)
                .Include(m => m.StudyModule)
                .ToListAsync();

            return View(currentLoggedInUserStudyHours);
        }

        // GET: StudyHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudyHour == null)
            {
                return NotFound();
            }

            var studyHours = await _context.StudyHour
                .Include(s => s.StudyModule)
                .FirstOrDefaultAsync(m => m.StudyHourId == id);
            if (studyHours == null)
            {
                return NotFound();
            }

            return View(studyHours);
        }

        // GET: StudyHours/Create
        public IActionResult Create()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Retrieve modules associated with the current logged-in user
            var modules = _context.Module
                .Where(m => m.UserID == userId)
                .ToList();

            ViewBag.ModuleId = new SelectList(modules, "ModuleId", "ModuleName"); // Ensure "ModuleName" matches the property name

            return View();
        }

        // POST: StudyHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudyHourId,ModuleId,StudyDate,Hours,UserID")] StudyHours studyHours)
        {
            if (studyHours is StudyHours)
            {
                //saving userid to database
                studyHours.UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(studyHours);
                await _context.SaveChangesAsync();
                if (_notyf != null)
                {
                    _notyf.Success("Study hours added to database");
                    _notyf.Success("You may now view Study Hours", 3);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studyHours);
        }

        // GET: StudyHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudyHour == null)
            {
                return NotFound();
            }

            var studyHours = await _context.StudyHour.FindAsync(id);
            if (studyHours == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", studyHours.ModuleId);
            return View(studyHours);
        }

        // POST: StudyHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudyHourId,ModuleId,StudyDate,Hours,UserID")] StudyHours studyHours)
        {
            if (id != studyHours.StudyHourId)
            {
                return NotFound();
            }

            if (studyHours is StudyHours)
            {
                try
                {
                    _context.Update(studyHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyHoursExists(studyHours.StudyHourId))
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
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleId", studyHours.ModuleId);
            return View(studyHours);
        }

        // GET: StudyHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudyHour == null)
            {
                return NotFound();
            }

            var studyHours = await _context.StudyHour
                .Include(s => s.StudyModule)
                .FirstOrDefaultAsync(m => m.StudyHourId == id);
            if (studyHours == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Module, "ModuleId", "ModuleName", studyHours.ModuleId);
            return View(studyHours);
            
        }

        // POST: StudyHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudyHour == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudyHour'  is null.");
            }
            var studyHours = await _context.StudyHour.FindAsync(id);
            if (studyHours != null)
            {
                _context.StudyHour.Remove(studyHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //bar graph method
        public IActionResult BarGraphFunction()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var BarGraphData = _context.StudyHour
                .Include(s => s.StudyModule)
                .Where(s => s.UserID== userId) // Adjust the property name accordingly
                .ToList();

            return View(BarGraphData);
        }

        private bool StudyHoursExists(int id)
        {
          return (_context.StudyHour?.Any(e => e.StudyHourId == id)).GetValueOrDefault();
        }
    }
}
