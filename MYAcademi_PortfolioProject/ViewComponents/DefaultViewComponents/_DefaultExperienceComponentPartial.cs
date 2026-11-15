using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;



namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultExperienceComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value=_context.Experiences.ToList();

            return View(value);
            
        }
    }
}
