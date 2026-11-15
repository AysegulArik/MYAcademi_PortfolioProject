
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var skills = _context.Skills
                .Include(s => s.SkillSkillItems)
                .ThenInclude(x => x.SkillItem)
                .ToList();

            return View(skills);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSkill(Skill skill, List<int> selectedSkillItemIds)
        {
            selectedSkillItemIds = selectedSkillItemIds.Distinct().ToList();

            if (selectedSkillItemIds.Count > 5)
            {
                ModelState.AddModelError("", "En fazla 5 teknoloji seçebilirsiniz.");
            }

            if (ModelState.IsValid)
            {
                skill.SkillSkillItems = selectedSkillItemIds
                    .Select(id => new SkillSkillItem
                    {
                        SkillItemId = id
                    })
                    .ToList();

                _context.Skills.Add(skill);
                _context.SaveChanges();

                return RedirectToAction("SkillList");
            }

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedSkillItemIds
            );

            return View(skill);
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills
                .Include(s => s.SkillSkillItems)
                .ThenInclude(x => x.SkillItem)
                .FirstOrDefault(s => s.SkillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            var selectedIds = skill.SkillSkillItems
                .Select(x => x.SkillItemId)
                .ToList();

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedIds
            );

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSkill(Skill skill, List<int> selectedSkillItemIds)
        {
            selectedSkillItemIds = selectedSkillItemIds.Distinct().ToList();

            var existingSkill = _context.Skills
                .Include(s => s.SkillSkillItems)
                .FirstOrDefault(s => s.SkillId == skill.SkillId);

            if (existingSkill == null)
            {
                return NotFound();
            }

            if (selectedSkillItemIds.Count > 5)
            {
                ModelState.AddModelError("", "En fazla 5 teknoloji seçebilirsiniz.");
            }

            if (selectedSkillItemIds.Any(id =>
                !_context.SkillItems.Any(x => x.SkillItemId == id)))
            {
                ModelState.AddModelError("", "Geçersiz teknoloji seçimi.");
            }

            if (ModelState.IsValid)
            {
                existingSkill.Title = skill.Title;
                existingSkill.Description = skill.Description;
                existingSkill.IconUrl = skill.IconUrl;

                existingSkill.SkillSkillItems.Clear();

                foreach (var id in selectedSkillItemIds)
                {
                    existingSkill.SkillSkillItems.Add(new SkillSkillItem
                    {
                        SkillId = existingSkill.SkillId,
                        SkillItemId = id
                    });
                }

                _context.SaveChanges();

                return RedirectToAction("SkillList");
            }

            ViewBag.SkillItems = new MultiSelectList(
                _context.SkillItems.ToList(),
                "SkillItemId",
                "SkillItemTitle",
                selectedSkillItemIds
            );

            return View(skill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills
                .Include(s => s.SkillSkillItems)
                .FirstOrDefault(s => s.SkillId == id);

            if (skill == null)
            {
                return NotFound();
            }

            // Önce kategoriye ait teknoloji bağlantılarını siliyoruz.
            _context.SkillSkillItems.RemoveRange(skill.SkillSkillItems);

            // Ardından yetenek kategorisini siliyoruz.
            _context.Skills.Remove(skill);

            _context.SaveChanges();

            return RedirectToAction("SkillList");
        }
    }
}
