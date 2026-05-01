using ContactManagementAPI.Models;

namespace ContactManagementAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
    }
}