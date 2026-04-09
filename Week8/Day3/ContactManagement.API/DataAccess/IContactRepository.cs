using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllContacts();
        Task<ContactInfo?> GetContactById(int id);
        Task<ContactInfo> AddContact(ContactInfo contact);
        Task<bool> UpdateContact(int id, ContactInfo contact);
        Task<bool> DeleteContact(int id);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}