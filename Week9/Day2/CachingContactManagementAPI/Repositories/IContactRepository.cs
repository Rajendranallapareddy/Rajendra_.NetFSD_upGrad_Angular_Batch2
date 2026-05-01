using ContactManagementAPI.Models;

namespace ContactManagementAPI.Repositories
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}