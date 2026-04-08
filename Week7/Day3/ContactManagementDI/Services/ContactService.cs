using ContactManagementDI.Models;

namespace ContactManagementDI.Services
{
    public class ContactService : IContactService
    {
        // Static list to maintain contact details (in-memory)
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        public ContactService()
        {
            // Add sample data if list is empty
            if (contacts.Count == 0)
            {
                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    CompanyName = "ABC Infotech",
                    EmailId = "rahul.sharma@abc.com",
                    MobileNo = 9876543210,
                    Designation = "Software Engineer"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Priya",
                    LastName = "Patel",
                    CompanyName = "XYZ Solutions",
                    EmailId = "priya.patel@xyz.com",
                    MobileNo = 9876543211,
                    Designation = "Project Manager"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Amit",
                    LastName = "Verma",
                    CompanyName = "Tech Innovations",
                    EmailId = "amit.verma@tech.com",
                    MobileNo = 9876543212,
                    Designation = "Senior Developer"
                });
            }
        }

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public void AddContact(ContactInfo contact)
        {
            contact.ContactId = nextId++;
            contacts.Add(contact);
        }
    }
}