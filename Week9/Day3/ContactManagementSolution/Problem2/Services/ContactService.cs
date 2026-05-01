using System;
using System.Collections.Generic;
using ContactManagement.Interfaces;
using ContactManagement.Models;

namespace ContactManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            if (contact == null)
                throw new Exception("Contact cannot be null");

            _repository.Add(contact);
        }

        public List<Contact> GetContacts()
        {
            return _repository.GetAll();
        }

        public bool RemoveContact(int id)
        {
            return _repository.Remove(id);
        }
    }
}
