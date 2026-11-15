using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroSectionController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HeroSectionController(PortfolioContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult UpdateHeroSection()
        {
            var value = _context.HeroSections.FirstOrDefault();

            if (value == null)
            {
                return NotFound("HeroSection kaydı bulunamadı.");
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateHeroSection(HeroSection heroSection, IFormFile imageFile)
        {
            var value = _context.HeroSections.FirstOrDefault();

            if (value == null)
            {
                return NotFound("HeroSection kaydı bulunamadı.");
            }

            // Mevcut fotoğraf yolunu koru
            ModelState.Remove(nameof(heroSection.MainImageUrl));
            heroSection.MainImageUrl = value.MainImageUrl;

            // Yeni fotoğraf seçilmişse kontrolleri yap
            if (imageFile != null && imageFile.Length > 0)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };

                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("MainImageUrl",
                        "Sadece JPG, JPEG, PNG ve WEBP dosyaları yüklenebilir.");
                }

                if (imageFile.Length > 3 * 1024 * 1024)
                {
                    ModelState.AddModelError("MainImageUrl",
                        "Fotoğraf boyutu en fazla 3 MB olabilir.");
                }
            }

            // Tüm alanların doğrulamasını yap
            if (!ModelState.IsValid)
            {
                return View(heroSection);
            }

            // Yeni fotoğraf seçilmişse klasöre kaydet
            if (imageFile != null && imageFile.Length > 0)
            {
                var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "hero");

                Directory.CreateDirectory(folderPath);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                heroSection.MainImageUrl = "/images/hero/" + fileName;
            }

            // Veritabanındaki bilgileri güncelle
            value.Greeting = heroSection.Greeting;
            value.Title = heroSection.Title;
            value.Description = heroSection.Description;
            value.MainImageUrl = heroSection.MainImageUrl;

            _context.SaveChanges();

            return RedirectToAction("UpdateHeroSection");
        }
    }
}