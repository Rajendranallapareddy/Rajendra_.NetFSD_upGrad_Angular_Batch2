using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Repository;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // All actions require authentication
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/contacts
        // Accessible by: Admin and User
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return Ok(contacts);
        }

        // GET: api/contacts/{id}
        // Accessible by: Admin and User
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ContactInfo>> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            
            if (contact == null)
                return NotFound(new { message = $"Contact with ID {id} not found" });
            
            return Ok(contact);
        }

        // POST: api/contacts
        // Accessible by: Admin only
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ContactInfo>> CreateContact([FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate CompanyId exists
            var companies = await _contactRepository.GetAllCompanies();
            if (!companies.Any(c => c.CompanyId == contact.CompanyId))
                return BadRequest(new { message = "Invalid Company ID" });

            // Validate DepartmentId exists
            var departments = await _contactRepository.GetAllDepartments();
            if (!departments.Any(d => d.DepartmentId == contact.DepartmentId))
                return BadRequest(new { message = "Invalid Department ID" });

            var createdContact = await _contactRepository.AddContact(contact);
            
            return CreatedAtAction(nameof(GetContactById), new { id = createdContact.ContactId }, createdContact);
        }

        // PUT: api/contacts/{id}
        // Accessible by: Admin only
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate CompanyId exists
            var companies = await _contactRepository.GetAllCompanies();
            if (!companies.Any(c => c.CompanyId == contact.CompanyId))
                return BadRequest(new { message = "Invalid Company ID" });

            // Validate DepartmentId exists
            var departments = await _contactRepository.GetAllDepartments();
            if (!departments.Any(d => d.DepartmentId == contact.DepartmentId))
                return BadRequest(new { message = "Invalid Department ID" });

            var updated = await _contactRepository.UpdateContact(id, contact);
            
            if (!updated)
                return NotFound(new { message = $"Contact with ID {id} not found" });
            
            return Ok(new { message = $"Contact with ID {id} updated successfully" });
        }

        // DELETE: api/contacts/{id}
        // Accessible by: Admin only
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var deleted = await _contactRepository.DeleteContact(id);
            
            if (!deleted)
                return NotFound(new { message = $"Contact with ID {id} not found" });
            
            return Ok(new { message = $"Contact with ID {id} deleted successfully" });
        }

        // GET: api/contacts/companies
        // Accessible by: Admin and User
        [HttpGet("companies")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _contactRepository.GetAllCompanies();
            return Ok(companies);
        }

        // GET: api/contacts/departments
        // Accessible by: Admin and User
        [HttpGet("departments")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await _contactRepository.GetAllDepartments();
            return Ok(departments);
        }
    }
}