using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

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

        public IActionResult ExperienceList()
        {   
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
