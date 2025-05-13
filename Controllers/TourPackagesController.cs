using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_and_Tourism.Models;

namespace Travel_and_Tourism.Controllers
{
    public class TourPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TourPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TourPackages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TourPackages.Include(t => t.TravelAgency);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TourPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _context.TourPackages
                .Include(t => t.TravelAgency)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            return View(tourPackage);
        }

        // GET: TourPackages/Create
        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName");
            return View();
        }

        // POST: TourPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourId,AgencyId,Title,Description,Price,Duration,AvailableDates,MaxGroupSize,ImageUrl")] TourPackage tourPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tourPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        // GET: TourPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        // POST: TourPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourId,AgencyId,Title,Description,Price,Duration,AvailableDates,MaxGroupSize,ImageUrl")] TourPackage tourPackage)
        {
            if (id != tourPackage.TourId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourPackageExists(tourPackage.TourId))
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
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        // GET: TourPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourPackage = await _context.TourPackages
                .Include(t => t.TravelAgency)
                .FirstOrDefaultAsync(m => m.TourId == id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            return View(tourPackage);
        }

        // POST: TourPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage != null)
            {
                _context.TourPackages.Remove(tourPackage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourPackageExists(int id)
        {
            return _context.TourPackages.Any(e => e.TourId == id);
        }
    }
}
