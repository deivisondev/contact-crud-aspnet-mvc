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

        public IActionResult Edit(int id)
        {
            Contact contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            Contact contactData = _context.Contacts.Find(contact.Id);

            if (contactData == null)
                return NotFound();

            contactData.Name = contact.Name;
            contactData.Cellphone = contact.Cellphone;
            contactData.Email = contact.Email;

            _context.Contacts.Update(contactData);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}