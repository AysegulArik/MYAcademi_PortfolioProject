using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var messages = _context.Messages.ToList();
            return View(messages);
        }
    }
}
