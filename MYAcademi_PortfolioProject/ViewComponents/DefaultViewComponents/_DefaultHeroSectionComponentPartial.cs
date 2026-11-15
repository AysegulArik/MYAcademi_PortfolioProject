using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeroSectionComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultHeroSectionComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.HeroSections.FirstOrDefault();
           
            if (value == null)
            {
                return View();
            }

            ViewBag.greeting = value.Greeting;
            ViewBag.title = value.Title;
            ViewBag.description = value.Description;
            ViewBag.mainImageUrl = value.MainImageUrl;

            var heroTitles = _context.HeroTitles
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .Select(x => x.Title)
                .ToList();

            ViewBag.heroTitles = heroTitles;

            return View();
        }   


    }
}
