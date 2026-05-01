using System.Collections.Generic;
using System.Linq;
using ContactManagement.Models;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool DeleteContact(int id)
        {
            var contact = GetContactById(id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                return true;
            }
            return false;
        }
    }
}
