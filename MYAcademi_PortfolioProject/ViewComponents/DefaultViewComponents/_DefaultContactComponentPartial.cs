using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultContactComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var values = _context.Contacts.ToList();
            return View(values);
        }
    }
}
