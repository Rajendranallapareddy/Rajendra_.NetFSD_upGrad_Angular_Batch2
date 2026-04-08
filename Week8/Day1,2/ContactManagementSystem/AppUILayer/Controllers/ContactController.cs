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
        public async Task<IActionResult> ShowContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return View(contacts);
        }

        // GET: Show contact details by ID
        [Route("GetContactById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
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
        public async Task<IActionResult> AddContact()
        {
            await LoadDropdowns();
            return View();
        }

        // POST: Add new contact
        [Route("AddContact")]
        [HttpPost]
        public async Task<IActionResult> AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            await LoadDropdowns();
            return View(contact);
        }

        // GET: Show Edit Contact Form
        [Route("EditContact/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditContact(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return RedirectToAction("ShowContacts");
            }
            await LoadDropdowns();
            return View(contact);
        }

        // POST: Update contact
        [Route("EditContact")]
        [HttpPost]
        public async Task<IActionResult> EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                await _contactRepository.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            await LoadDropdowns();
            return View(contact);
        }

        // GET: Show Delete Confirmation
        [Route("DeleteContact/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return RedirectToAction("ShowContacts");
            }
            return View(contact);
        }

        // POST: Confirm Delete
        [Route("DeleteContact")]
        [HttpPost]
        public async Task<IActionResult> DeleteContactConfirmed(int contactId)
        {
            await _contactRepository.DeleteContact(contactId);
            return RedirectToAction("ShowContacts");
        }

        private async Task LoadDropdowns()
        {
            ViewBag.Companies = await _contactRepository.GetAllCompanies();
            ViewBag.Departments = await _contactRepository.GetAllDepartments();
        }
    }
}