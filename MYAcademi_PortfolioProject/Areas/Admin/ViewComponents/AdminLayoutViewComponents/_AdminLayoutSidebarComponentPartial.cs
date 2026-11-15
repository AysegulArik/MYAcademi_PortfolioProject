using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;


namespace MYAcademi_PortfolioProject.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _AdminLayoutSidebarComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.BekleyenMesajSayisi = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.ToplamDeneyimSayisi = _context.Experiences.Count();
            return View();
        }
    }
}
