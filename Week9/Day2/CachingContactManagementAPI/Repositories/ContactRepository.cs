using ContactManagementAPI.Models;

namespace ContactManagementAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> _contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "Kartik", Email = "kartik@gmail.com" },
            new Contact { Id = 2, Name = "Rahul", Email = "rahul@gmail.com" },
            new Contact { Id = 3, Name = "Aman", Email = "aman@gmail.com" }
        };

        public List<Contact> GetAllContacts()
        {
            Console.WriteLine("Fetching from DATABASE...");
            return _contacts;
        }

        public Contact GetContactById(int id)
        {
            Console.WriteLine("Fetching single contact from DATABASE...");
            return _contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}