using Microsoft.AspNetCore.Mvc;

namespace MYAcademi_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
