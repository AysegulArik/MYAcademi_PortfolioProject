using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultSkillsComponentPartial : ViewComponent
    {
    private readonly PortfolioContext _context;

        public _DefaultSkillsComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var skills = _context.Skills
     .Include(s => s.SkillSkillItems)
         .ThenInclude(x => x.SkillItem).ToList();
            return View(skills);
           
        }
    }
}
