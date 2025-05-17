using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var tourPackages = _context.TourPackages.Include(t => t.TravelAgency);
            return View(await tourPackages.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tourPackage = await _context.TourPackages
                .Include(t => t.TravelAgency)
                .FirstOrDefaultAsync(m => m.TourId == id);

            if (tourPackage == null) return NotFound();

            return View(tourPackage);
        }

        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TourPackage tourPackage)
        {
            if (ModelState.IsValid)
            {
                if (tourPackage.ImageFile != null && tourPackage.ImageFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await tourPackage.ImageFile.CopyToAsync(memoryStream);
                        tourPackage.ImageUrl = memoryStream.ToArray();
                    }
                }

                _context.Add(tourPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage == null) return NotFound();

            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TourPackage tourPackage)
        {
            if (id != tourPackage.TourId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existing = await _context.TourPackages.AsNoTracking().FirstOrDefaultAsync(t => t.TourId == id);

                    if (tourPackage.ImageFile != null && tourPackage.ImageFile.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await tourPackage.ImageFile.CopyToAsync(memoryStream);
                            tourPackage.ImageUrl = memoryStream.ToArray();
                        }
                    }
                    else
                    {
                        tourPackage.ImageUrl = existing?.ImageUrl;
                    }

                    _context.Update(tourPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourPackageExists(tourPackage.TourId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AgencyId"] = new SelectList(_context.TravelAgencies, "AgencyId", "AgencyName", tourPackage.AgencyId);
            return View(tourPackage);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tourPackage = await _context.TourPackages
                .Include(t => t.TravelAgency)
                .FirstOrDefaultAsync(m => m.TourId == id);

            if (tourPackage == null) return NotFound();

            return View(tourPackage);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage != null)
            {
                _context.TourPackages.Remove(tourPackage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TourPackageExists(int id)
        {
            return _context.TourPackages.Any(e => e.TourId == id);
        }
    }
}
