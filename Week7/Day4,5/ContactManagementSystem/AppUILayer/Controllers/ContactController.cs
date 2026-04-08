using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;

namespace AppUILayer.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: Show all contacts
        [Route("ShowContacts")]
        [HttpGet]
        public IActionResult ShowContacts()
        {
            var contacts = _contactRepository.GetAllContacts();
            return View(contacts);
        }

        // GET: Show contact details by ID
        [Route("GetContactById/{id}")]
        [HttpGet]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                ViewBag.ErrorMessage = $"Contact with ID {id} not found!";
                return View("ContactNotFound");
            }
            return View(contact);
        }

        // GET: Show Add Contact Form
        [Route("AddContact")]
        [HttpGet]
        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        // POST: Add new contact
        [Route("AddContact")]
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            LoadDropdowns();
            return View(contact);
        }

        // GET: Show Edit Contact Form
        [Route("EditContact/{id}")]
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return RedirectToAction("ShowContacts");
            }
            LoadDropdowns();
            return View(contact);
        }

        // POST: Update contact
        [Route("EditContact")]
        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _contactRepository.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            LoadDropdowns();
            return View(contact);
        }

        // GET: Show Delete Confirmation
        [Route("DeleteContact/{id}")]
        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return RedirectToAction("ShowContacts");
            }
            return View(contact);
        }

        // POST: Confirm Delete
        [Route("DeleteContact")]
        [HttpPost]
        public IActionResult DeleteContactConfirmed(int contactId)
        {
            _contactRepository.DeleteContact(contactId);
            return RedirectToAction("ShowContacts");
        }

        private void LoadDropdowns()
        {
            ViewBag.Companies = _contactRepository.GetAllCompanies();
            ViewBag.Departments = _contactRepository.GetAllDepartments();
        }
    }
}