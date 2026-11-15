using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }


        public IActionResult ExperienceList(int page = 1)
        {
            int pageSize = 4;

            var totalCount = _context.Experiences.Count();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Geçersiz sayfa numaralarını engelle
            if (page < 1)
                page = 1;

            if (totalPages > 0 && page > totalPages)
                page = totalPages;

            var values = _context.Experiences
                .OrderBy(x => x.ExperienceId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalCount = totalCount;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartRecord = totalCount == 0 ? 0 : (page - 1) * pageSize + 1;
            ViewBag.EndRecord = Math.Min(page * pageSize, totalCount);

            return View(values);
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(value);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Deneyim başarıyla silindi.";

            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExperience(Experience experience)
        {
            var value = _context.Experiences.Find(experience.ExperienceId);

            if (value == null)
            {
                return NotFound();
            }

            value.Title = experience.Title;
            value.CompanyName = experience.CompanyName;
            value.CategoryName = experience.CategoryName;
            value.Description = experience.Description;
            value.IsActive = experience.IsActive;

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Deneyim başarıyla güncellendi.";

            return RedirectToAction("ExperienceList");
        }

        
    }
}
