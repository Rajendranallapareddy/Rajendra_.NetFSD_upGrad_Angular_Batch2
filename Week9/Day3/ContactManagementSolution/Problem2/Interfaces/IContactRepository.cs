using System.Collections.Generic;
using ContactManagement.Models;

namespace ContactManagement.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        bool Remove(int id);
    }
}
