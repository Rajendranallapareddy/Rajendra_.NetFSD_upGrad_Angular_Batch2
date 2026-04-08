using Microsoft.AspNetCore.Mvc;
using ContactManagementDI.Models;
using ContactManagementDI.Services;

namespace ContactManagementDI.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        // Dependency Injection via constructor
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Action 1: Show all contacts
        [Route("ShowContacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // Action 2: Get contact by ID
        [Route("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
            {
                ViewBag.ErrorMessage = $"Contact with ID {id} not found!";
                return View("ContactNotFound");
            }

            return View(contact);
        }

        // Action 3: GET - Show Add Contact Form
        [Route("AddContact")]
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        // Action 4: POST - Save new contact
        [Route("AddContact")]
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contactInfo);
                return RedirectToAction("ShowContacts");
            }

            return View(contactInfo);
        }
    }
}