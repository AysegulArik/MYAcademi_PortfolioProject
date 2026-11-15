using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultProjectComponentPartial : ViewComponent
    {

        private readonly PortfolioContext _context;


        public _DefaultProjectComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects
                .Include(x => x.ProjectCategories)
                    .ThenInclude(x => x.Category)
                .Include(x => x.ProjectSkillItems)
                    .ThenInclude(x => x.SkillItem)
                .OrderBy(x => x.DisplayOrder)
                .ToList();

            return View(projects);
        }
    }
}
