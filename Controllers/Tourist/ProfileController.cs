using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel_and_Tourism.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

[Authorize]  // Ensure that only logged-in users can access the profile details
public class ProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ProfileController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
    {
        _context = context;
        _hostingEnvironment = hostingEnvironment;
    }

    // Profile Details Page
    public async Task<IActionResult> Details()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return RedirectToAction("Login", "Account");
        }

        var userId = int.Parse(userIdClaim);

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
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdClaim))
        {
            return RedirectToAction("Login", "Account");
        }

        var userId = int.Parse(userIdClaim);

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
        if (ModelState.IsValid)
        {
            var user = await _context.RegisteredUsers
                .FirstOrDefaultAsync(u => u.UserId == model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            // Update the user information
            user.FirstName = model.FirstName;
            user.Lastname = model.Lastname;
            user.Email = model.Email;

            // Handle profile picture update
            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {
                // Generate the file name
                string fileName = Path.GetFileName(model.ProfilePicture.FileName);
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "UploadedImages");

                // Ensure the directory exists
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Define the full path to save the file
                string fullPath = Path.Combine(uploadFolder, fileName);

                // Save the file to the server
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(stream);
                }

                // Update the user profile picture path
                user.ProfilePicturePath = "/UploadedImages/" + fileName;
            }

            // Update user in the database
            _context.Update(user);
            await _context.SaveChangesAsync();

            // Redirect to the details page to show updated profile
            return RedirectToAction("Details");
        }

        return View(model);
    }
}
