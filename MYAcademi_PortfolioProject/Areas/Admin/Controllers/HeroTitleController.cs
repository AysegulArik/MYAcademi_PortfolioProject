
using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroTitleController : Controller
    {
        private readonly PortfolioContext _context;

        public HeroTitleController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult HeroTitleList()
        {
            var values = _context.HeroTitles
                .OrderBy(x => x.Order)
                .ToList();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateHeroTitle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateHeroTitle(HeroTitle heroTitle)
        {
            // Aynı sıra numarası var mı kontrol et
            var orderExists = _context.HeroTitles
                .Any(x => x.Order == heroTitle.Order);

            if (orderExists)
            {
                ModelState.AddModelError("Order",
                    "Bu gösterim sırası zaten kullanılıyor.");
            }

            if (ModelState.IsValid)
            {
                _context.HeroTitles.Add(heroTitle);
                _context.SaveChanges();

                return RedirectToAction("HeroTitleList");
            }

            return View(heroTitle);
        }

        [HttpGet]
        public IActionResult UpdateHeroTitle(int id)
        {
            var value = _context.HeroTitles.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateHeroTitle(HeroTitle heroTitle)
        {
            var value = _context.HeroTitles.Find(heroTitle.HeroTitleId);

            if (value == null)
            {
                return NotFound();
            }

            // Başka bir kayıtta aynı sıra numarası var mı?
            var orderExists = _context.HeroTitles.Any(x =>
                x.Order == heroTitle.Order &&
                x.HeroTitleId != heroTitle.HeroTitleId);

            if (orderExists)
            {
                ModelState.AddModelError("Order",
                    "Bu gösterim sırası başka bir başlık tarafından kullanılıyor.");
            }

            if (ModelState.IsValid)
            {
                value.Title = heroTitle.Title;
                value.Order = heroTitle.Order;
                value.IsActive = heroTitle.IsActive;

                _context.SaveChanges();

                return RedirectToAction("HeroTitleList");
            }

            return View(heroTitle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteHeroTitle(int id)
        {
            var value = _context.HeroTitles.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.HeroTitles.Remove(value);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Animasyon başlığı başarıyla silindi.";

            return RedirectToAction("HeroTitleList");
        }



    }
}
