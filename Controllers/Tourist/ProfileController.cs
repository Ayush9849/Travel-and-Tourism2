using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_and_Tourism.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Security.Claims;

public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ProfileController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
    {
        _context = context;
        _hostingEnvironment = hostingEnvironment;
    }

    // Profile Details
    public async Task<IActionResult> Details()
    {
        int userId = 1; // Static test user ID

        //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //int userId = int.Parse(userIdClaim);

        var user = await _context.RegisteredUsers
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // Edit Profile (GET)
    public async Task<IActionResult> Edit()
    {
        int userId = 1; // Static test user ID

        var user = await _context.RegisteredUsers
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // Edit Profile (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(RegisteredUser model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _context.RegisteredUsers
            .FirstOrDefaultAsync(u => u.UserId == model.UserId);

        if (user == null)
        {
            return NotFound();
        }

        // Update user info
        user.FirstName = model.FirstName;
        user.Lastname = model.Lastname;
        user.Email = model.Email;

        // Profile picture upload
        if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
        {
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "UploadedImages");
            Directory.CreateDirectory(uploadFolder); // Make sure folder exists

            var fileName = Path.GetFileName(model.ProfilePicture.FileName);
            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.ProfilePicture.CopyToAsync(stream);
            }

            user.ProfilePicturePath = "/UploadedImages/" + fileName;
        }

        _context.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Details");
    }
}
