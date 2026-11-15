using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

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


        public IActionResult MessageList(int page = 1)
        {
            int pageSize = 5;

            var totalCount = _context.Messages.Count();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (page < 1)
                page = 1;

            if (totalPages > 0 && page > totalPages)
                page = totalPages;

            var messages = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .ThenByDescending(x => x.MessageId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalCount = totalCount;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartRecord = totalCount == 0 ? 0 : (page - 1) * pageSize + 1;
            ViewBag.EndRecord = Math.Min(page * pageSize, totalCount);

            return View(messages);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
                return NotFound();

            _context.Messages.Remove(value);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Mesaj başarıyla silindi.";

            return RedirectToAction("MessageList");
        }


        [HttpGet]
        public IActionResult MessageDetail(int id)
        {
            var value = _context.Messages.Find(id);

            if (value == null)
                return NotFound();

            value.IsRead = true;

            _context.SaveChanges();

            return PartialView("_MessageDetailPartial", value);
        }


    }
}
