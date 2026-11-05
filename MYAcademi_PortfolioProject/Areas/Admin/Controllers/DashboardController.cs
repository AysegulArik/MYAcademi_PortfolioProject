using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1=_context.Messages.Count();
            ViewBag.v2=_context.Messages.Where(x => x.IsRead ==false).Count();
            ViewBag.v3=_context.Messages.Where(x => x.IsRead == true).Count();
            return View();
        }
    }
}
