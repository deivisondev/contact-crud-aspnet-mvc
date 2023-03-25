using ContactCrudAspNetMvc.Context;
using ContactCrudAspNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactCrudAspNetMvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly ScheduleContext _context;
        public ContactController(ScheduleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Contact> contactList = _context.Contacts.ToList<Contact>();

            return View(contactList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                DateTimeOffset dateTimeOffset = new DateTimeOffset(new DateTime());

                contact.CreationDate = dateTimeOffset.UtcDateTime;

                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }
    }
}