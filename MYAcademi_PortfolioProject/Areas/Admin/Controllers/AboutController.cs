
using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AboutController(
            PortfolioContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult UpdateAbout()
        {
            var value = _context.Abouts.FirstOrDefault();

            if (value == null)
            {
                return NotFound("Hakkımda kaydı bulunamadı.");
            }

            return View(value);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAbout(About about, IFormFile? imageFile)
        {
            var value = _context.Abouts.FirstOrDefault();

            if (value == null)
            {
                return NotFound("Hakkımda kaydı bulunamadı.");
            }

            // Mevcut fotoğraf yolunu koru
            ModelState.Remove(nameof(about.ImageUrl));
            about.ImageUrl = value.ImageUrl;

            // Yeni fotoğraf seçilmişse kontrolleri yap
            if (imageFile != null && imageFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };

                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageUrl",
                        "Sadece JPG, JPEG, PNG ve WEBP dosyaları yüklenebilir.");
                }

                if (imageFile.Length > 3 * 1024 * 1024)
                {
                    ModelState.AddModelError("ImageUrl",
                        "Fotoğraf boyutu en fazla 3 MB olabilir.");
                }
            }


            if (!ModelState.IsValid)
            {
                return View(about);
            }

            // Yeni fotoğraf seçilmişse kaydet
            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "about");

                Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString()
                               + Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                about.ImageUrl = "/images/about/" + fileName;
            }

            // Diğer alanları güncelle
            value.Title = about.Title;
            value.Description = about.Description;
            value.Description2 = about.Description2;
            value.ImageUrl = about.ImageUrl;
            value.Experience = about.Experience;
            value.EducationCount = about.EducationCount;
            value.StudentCount = about.StudentCount;
            value.ProfileInfo = about.ProfileInfo;
            value.PositionTitle = about.PositionTitle;
            value.ResumeUrl = about.ResumeUrl;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Hakkımda bilgileri başarıyla güncellendi.";

            return RedirectToAction("UpdateAbout");
        }

    }
}
