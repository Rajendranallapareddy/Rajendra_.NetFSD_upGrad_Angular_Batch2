using DataAccessLayer.Models;

namespace DataAccessLayer.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<ContactInfo>> GetAllContacts();
        Task<ContactInfo> GetContactById(int id);
        Task<int> AddContact(ContactInfo contact);
        Task<bool> UpdateContact(ContactInfo contact);
        Task<bool> DeleteContact(int id);
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<IEnumerable<Department>> GetAllDepartments();
    }
}