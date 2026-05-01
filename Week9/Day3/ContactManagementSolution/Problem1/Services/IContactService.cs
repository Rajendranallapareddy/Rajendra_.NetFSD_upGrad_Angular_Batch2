using System.Collections.Generic;
using ContactManagement.Models;

namespace ContactManagement.Services
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        bool DeleteContact(int id);
    }
}
