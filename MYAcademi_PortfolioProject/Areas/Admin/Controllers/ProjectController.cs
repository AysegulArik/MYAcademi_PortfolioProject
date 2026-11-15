using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }
        public IActionResult ProjectList()
        {
            var values = _context.Projects
       .Include(x => x.ProjectCategories)
       .ThenInclude(x => x.Category)
       .Include(x => x.ProjectSkillItems)
       .ThenInclude(x => x.SkillItem)
       .OrderBy(x => x.DisplayOrder)
       .ToList();

            return View(values);
        }
        [HttpGet]
        public IActionResult ProjectCreat()
        {
            ViewBag.Categories = new MultiSelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName"
            );

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProjectCreat(Project project, List<int> selectedCategoryIds, List<int> selectedSkillItemIds)
        {
            selectedCategoryIds = selectedCategoryIds.Distinct().ToList();
            selectedSkillItemIds = selectedSkillItemIds.Distinct().ToList();

            if (selectedCategoryIds.Any(id => !_context.Categories.Any(x => x.CategoryId == id)))
            {
                ModelState.AddModelError("", "Geçersiz kategori seçimi.");
            }

            if (selectedSkillItemIds.Any(id => !_context.SkillItems.Any(x => x.SkillItemId == id)))
            {
                ModelState.AddModelError("", "Geçersiz teknoloji seçimi.");
            }

            if (ModelState.IsValid)
            {
                project.ProjectCategories = selectedCategoryIds
                    .Select(id => new ProjectCategory
                    {
                        CategoryId = id
                    }).ToList();

                project.ProjectSkillItems = selectedSkillItemIds
                    .Select(id => new ProjectSkillItem
                    {
                        SkillItemId = id
                    }).ToList();

                _context.Projects.Add(project);
                _context.SaveChanges();

                return RedirectToAction("ProjectList");
            }

            ViewBag.Categories = new MultiSelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName",
                selectedCategoryIds
            );

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedSkillItemIds
            );

            return View(project);
        }
        [HttpGet]
        public IActionResult ProjectUpdate(int id)
        {
            var project = _context.Projects
                .Include(x => x.ProjectCategories)
                .Include(x => x.ProjectSkillItems)
                .FirstOrDefault(x => x.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            var selectedCategoryIds = project.ProjectCategories
                .Select(x => x.CategoryId)
                .ToList();

            var selectedSkillItemIds = project.ProjectSkillItems
                .Select(x => x.SkillItemId)
                .ToList();

            ViewBag.Categories = new MultiSelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName",
                selectedCategoryIds
            );

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedSkillItemIds
            );

            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProjectUpdate(Project project, List<int> selectedCategoryIds, List<int> selectedSkillItemIds)
        {
            selectedCategoryIds = selectedCategoryIds.Distinct().ToList();
            selectedSkillItemIds = selectedSkillItemIds.Distinct().ToList();

            var existingProject = _context.Projects
                .Include(x => x.ProjectCategories)
                .Include(x => x.ProjectSkillItems)
                .FirstOrDefault(x => x.ProjectId == project.ProjectId);

            if (existingProject == null)
            {
                return NotFound();
            }

            if (selectedCategoryIds.Any(id => !_context.Categories.Any(x => x.CategoryId == id)))
            {
                ModelState.AddModelError("", "Geçersiz kategori seçimi.");
            }

            if (selectedSkillItemIds.Any(id => !_context.SkillItems.Any(x => x.SkillItemId == id)))
            {
                ModelState.AddModelError("", "Geçersiz teknoloji seçimi.");
            }

            if (ModelState.IsValid)
            {
                existingProject.ProjectTitle = project.ProjectTitle;
                existingProject.Description = project.Description;
                existingProject.ImageUrl = project.ImageUrl;
                existingProject.ProjectUrl = project.ProjectUrl;
                existingProject.GithubUrl = project.GithubUrl;
                existingProject.StatusText = project.StatusText;
                existingProject.StatusIcon = project.StatusIcon;
                existingProject.IsFeatured = project.IsFeatured;
                existingProject.DisplayOrder = project.DisplayOrder;

                _context.ProjectCategories.RemoveRange(existingProject.ProjectCategories);
                _context.ProjectSkillItems.RemoveRange(existingProject.ProjectSkillItems);

                existingProject.ProjectCategories = selectedCategoryIds
                    .Select(id => new ProjectCategory
                    {
                        ProjectId = existingProject.ProjectId,
                        CategoryId = id
                    }).ToList();

                existingProject.ProjectSkillItems = selectedSkillItemIds
                    .Select(id => new ProjectSkillItem
                    {
                        ProjectId = existingProject.ProjectId,
                        SkillItemId = id
                    }).ToList();

                _context.SaveChanges();

                return RedirectToAction("ProjectList");
            }

            ViewBag.Categories = new MultiSelectList(
                _context.Categories.ToList(),
                "CategoryId",
                "CategoryName",
                selectedCategoryIds
            );

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedSkillItemIds
            );

            return View(project);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProjectDelete(int id)
        {
            var project = _context.Projects
                .Include(x => x.ProjectCategories)
                .Include(x => x.ProjectSkillItems)
                .FirstOrDefault(x => x.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            _context.ProjectCategories.RemoveRange(project.ProjectCategories);
            _context.ProjectSkillItems.RemoveRange(project.ProjectSkillItems);

            _context.Projects.Remove(project);

            _context.SaveChanges();

            TempData["SuccessMessage"] = "Proje başarıyla silindi.";

            return RedirectToAction("ProjectList");
        }
    }
}
