using Microsoft.AspNetCore.Mvc;
using System.IO;
using Travel_and_Tourism.Models;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class TouristRegisterController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ApplicationDbContext _context;

    public TouristRegisterController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
    {
        _hostingEnvironment = hostingEnvironment;
        _context = context;
    }
    //public RegisterController(IWebHostEnvironment hostingEnvironment)
    //{
    //    _hostingEnvironment = hostingEnvironment;
    //}

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(RegistrationViewModel model)
    {
        if (ModelState.IsValid)
        {
            string filePath = null;

            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {
                string fileName = Path.GetFileName(model.ProfilePicture.FileName);

                // Save to wwwroot/UploadedImages
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "UploadedImages");

                // Create folder if it doesn't exist
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string fullPath = Path.Combine(uploadFolder, fileName);

                // Save the file
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(stream);
                }

                // Store relative path (for later retrieval/display)
                filePath = "/UploadedImages/" + fileName;
            }

            var user = new RegisteredUser
            {
                FirstName = model.FirstName,
                Lastname = model.LastName,
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                ProfilePicturePath = filePath
            };


            _context.RegisteredUsers.Add(user);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        return View(model);
    }
}
