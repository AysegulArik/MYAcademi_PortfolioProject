using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

namespace MYAcademi_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.SenderName) ||
                string.IsNullOrWhiteSpace(message.SenderEmail) ||
                string.IsNullOrWhiteSpace(message.MessageDetail))
            {
                TempData["ContactMessage"] = "Lütfen zorunlu alanları doldurun.";
                return RedirectToAction(nameof(Index), "Default", null, "contact");
            }

            message.Subject = string.IsNullOrWhiteSpace(message.Subject)
                ? "Genel"
                : message.Subject;

            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["ContactMessage"] = "Mesajınız başarıyla gönderildi.";
            return RedirectToAction(nameof(Index), "Default", null, "contact");
        }
    }
}
