using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManagementAPI.Data;
using ContactManagementAPI.Models;
using ContactManagementAPI.DTOs;

namespace ContactManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts(int pageNumber = 1, int pageSize = 5)
        {
            // Total Records
            var totalRecords = await _context.Contacts.CountAsync();

            // Paging Logic
            var contacts = await _context.Contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Total Pages
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var response = new PagedResponse<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = contacts
            };

            return Ok(response);
        }
    }
}