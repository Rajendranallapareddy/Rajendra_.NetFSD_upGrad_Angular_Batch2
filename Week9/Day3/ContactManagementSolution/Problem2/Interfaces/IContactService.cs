using System.Collections.Generic;
using ContactManagement.Models;

namespace ContactManagement.Interfaces
{
    public interface IContactService
    {
        void AddContact(Contact contact);
        List<Contact> GetContacts();
        bool RemoveContact(int id);
    }
}
