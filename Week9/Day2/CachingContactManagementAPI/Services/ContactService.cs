using ContactManagementAPI.Models;
using ContactManagementAPI.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ContactManagementAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string cacheKey = "contactList";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                contacts = _repository.GetAllContacts();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, cacheOptions);
            }
            else
            {
                Console.WriteLine("Fetching from CACHE...");
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = _repository.GetContactById(id);

                if (contact != null)
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, cacheOptions);
                }
            }
            else
            {
                Console.WriteLine("Fetching single contact from CACHE...");
            }

            return contact;
        }
    }
}