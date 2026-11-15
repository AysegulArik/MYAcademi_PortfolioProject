using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultEducationSectionComponentPartial : ViewComponent
    {
       private readonly PortfolioContext _context;

        public _DefaultEducationSectionComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var educations = _context.Educations.ToList();
            return View(educations);
        }
    }
}
