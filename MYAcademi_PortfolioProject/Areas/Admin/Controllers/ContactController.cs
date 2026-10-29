using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View();
        }
    }
}
