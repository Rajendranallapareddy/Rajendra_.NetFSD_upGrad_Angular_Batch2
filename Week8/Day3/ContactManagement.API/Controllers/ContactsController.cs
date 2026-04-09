using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.DataAccess;
using ContactManagement.API.Models;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// GET: api/contacts
        /// Get all contacts
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllContacts();
            return Ok(contacts);
        }

        /// <summary>
        /// GET: api/contacts/{id}
        /// Get contact by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInfo>> GetContactById(int id)
        {
            var contact = await _contactRepository.GetContactById(id);
            
            if (contact == null)
                return NotFound(new { message = $"Contact with ID {id} not found" });
            
            return Ok(contact);
        }

        /// <summary>
        /// POST: api/contacts
        /// Create a new contact
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ContactInfo>> CreateContact([FromBody] ContactInfo contact)
        {
            // Validate required fields
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

        /// <summary>
        /// PUT: api/contacts/{id}
        /// Update an existing contact
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] ContactInfo contact)
        {
            // Validate required fields
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

        /// <summary>
        /// DELETE: api/contacts/{id}
        /// Delete a contact
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var deleted = await _contactRepository.DeleteContact(id);
            
            if (!deleted)
                return NotFound(new { message = $"Contact with ID {id} not found" });
            
            return Ok(new { message = $"Contact with ID {id} deleted successfully" });
        }

        /// <summary>
        /// GET: api/contacts/companies
        /// Get all companies (for dropdown)
        /// </summary>
        [HttpGet("companies")]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _contactRepository.GetAllCompanies();
            return Ok(companies);
        }

        /// <summary>
        /// GET: api/contacts/departments
        /// Get all departments (for dropdown)
        /// </summary>
        [HttpGet("departments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartments()
        {
            var departments = await _contactRepository.GetAllDepartments();
            return Ok(departments);
        }
    }
}