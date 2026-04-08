using Microsoft.AspNetCore.Mvc;
using ContactManagement.Models;
using System.Linq;

namespace ContactManagement.Controllers
{
    [Route("[controller]")]
    public class ContactController : Controller
    {
        // Static list to maintain contact details (in-memory)
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        // Constructor to add some sample data
        public ContactController()
        {
            if (contacts.Count == 0)
            {
                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    CompanyName = "ABC Infotech",
                    EmailId = "rahul.sharma@abc.com",
                    MobileNo = 9876543210,
                    Designation = "Software Engineer"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Priya",
                    LastName = "Patel",
                    CompanyName = "XYZ Solutions",
                    EmailId = "priya.patel@xyz.com",
                    MobileNo = 9876543211,
                    Designation = "Project Manager"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Amit",
                    LastName = "Verma",
                    CompanyName = "Tech Innovations",
                    EmailId = "amit.verma@tech.com",
                    MobileNo = 9876543212,
                    Designation = "Senior Developer"
                });
            }
        }

        // Action 1: Show all contacts
        [Route("ShowContacts")]
        public ActionResult ShowContacts()
        {
            return View(contacts);
        }

        // Action 2: Get contact by ID using LINQ
        [Route("GetContactById/{id}")]
        public ActionResult GetContactById(int id)
        {
            // Using LINQ to search contact by ContactId
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
            {
                ViewBag.ErrorMessage = $"Contact with ID {id} not found!";
                return View("ContactNotFound");
            }

            return View(contact);
        }

        // Action 3: GET - Show Add Contact Form
        [Route("AddContact")]
        public ActionResult AddContact()
        {
            return View();
        }

        // Action 4: POST - Save new contact
        [HttpPost]
        [Route("AddContact")]
        public ActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                // Assign new ID
                contactInfo.ContactId = nextId++;
                
                // Add to list
                contacts.Add(contactInfo);
                
                // Redirect to ShowContacts view
                return RedirectToAction("ShowContacts");
            }
            
            // If validation fails, return the same view with errors
            return View(contactInfo);
        }
    }
}