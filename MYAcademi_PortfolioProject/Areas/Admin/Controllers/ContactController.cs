using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using MYAcademi_PortfolioProject.Entities;

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
            return View(values);
        }
        [HttpGet]

        public IActionResult CreateContact()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var value = _context.Contacts.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contact contact)
        {
            var value = _context.Contacts.Find(contact.ContactId);

            if (value == null)
            {
                return NotFound();
            }

            value.Title = contact.Title;
            value.Description = contact.Description;
            value.Email = contact.Email;
            value.PhoneNumber = contact.PhoneNumber;
            value.Location = contact.Location;

            _context.SaveChanges();

            return RedirectToAction("ContactList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(value);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "İletişim bilgisi başarıyla silindi.";

            return RedirectToAction("ContactList");
        }
    }
}
