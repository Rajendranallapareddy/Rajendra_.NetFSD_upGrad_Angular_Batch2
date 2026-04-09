using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL.Data;
using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllContacts()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        public async Task<ContactInfo?> GetContactById(int id)
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task<ContactInfo> AddContact(ContactInfo contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> UpdateContact(int id, ContactInfo contact)
        {
            var existingContact = await _context.Contacts.FindAsync(id);
            if (existingContact == null)
                return false;

            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.EmailId = contact.EmailId;
            existingContact.MobileNo = contact.MobileNo;
            existingContact.Designation = contact.Designation;
            existingContact.CompanyId = contact.CompanyId;
            existingContact.DepartmentId = contact.DepartmentId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}