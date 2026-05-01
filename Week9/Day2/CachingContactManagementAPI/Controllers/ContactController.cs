using ContactManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _service.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _service.GetContactById(id);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
    }
}