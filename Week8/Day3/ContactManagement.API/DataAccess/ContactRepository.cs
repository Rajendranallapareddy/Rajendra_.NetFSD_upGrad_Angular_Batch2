using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        // Static in-memory data storage
        private static List<ContactInfo> contacts = new List<ContactInfo>();
        private static int nextId = 1;

        // Static master data for Companies and Departments
        private static List<Company> companies = new List<Company>
        {
            new Company { CompanyId = 1, CompanyName = "TCS" },
            new Company { CompanyId = 2, CompanyName = "Infosys" },
            new Company { CompanyId = 3, CompanyName = "Wipro" },
            new Company { CompanyId = 4, CompanyName = "HCL Technologies" },
            new Company { CompanyId = 5, CompanyName = "Tech Mahindra" }
        };

        private static List<Department> departments = new List<Department>
        {
            new Department { DepartmentId = 1, DepartmentName = "HR" },
            new Department { DepartmentId = 2, DepartmentName = "IT" },
            new Department { DepartmentId = 3, DepartmentName = "Finance" },
            new Department { DepartmentId = 4, DepartmentName = "Marketing" },
            new Department { DepartmentId = 5, DepartmentName = "Sales" }
        };

        public ContactRepository()
        {
            // Add sample data if list is empty
            if (contacts.Count == 0)
            {
                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    EmailId = "rahul.sharma@tcs.com",
                    MobileNo = 9876543210,
                    Designation = "Software Engineer",
                    CompanyId = 1,
                    DepartmentId = 2,
                    CompanyName = "TCS",
                    DepartmentName = "IT"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Priya",
                    LastName = "Patel",
                    EmailId = "priya.patel@infosys.com",
                    MobileNo = 9876543211,
                    Designation = "Project Manager",
                    CompanyId = 2,
                    DepartmentId = 2,
                    CompanyName = "Infosys",
                    DepartmentName = "IT"
                });

                contacts.Add(new ContactInfo
                {
                    ContactId = nextId++,
                    FirstName = "Amit",
                    LastName = "Verma",
                    EmailId = "amit.verma@wipro.com",
                    MobileNo = 9876543212,
                    Designation = "Senior Developer",
                    CompanyId = 3,
                    DepartmentId = 2,
                    CompanyName = "Wipro",
                    DepartmentName = "IT"
                });
            }
        }

        public async Task<IEnumerable<ContactInfo>> GetAllContacts()
        {
            return await Task.Run(() => contacts);
        }

        public async Task<ContactInfo?> GetContactById(int id)
        {
            return await Task.Run(() => contacts.FirstOrDefault(c => c.ContactId == id));
        }

        public async Task<ContactInfo> AddContact(ContactInfo contact)
        {
            return await Task.Run(() =>
            {
                // Auto-generate ContactId
                contact.ContactId = nextId++;
                
                // Set CompanyName and DepartmentName from master data
                var company = companies.FirstOrDefault(c => c.CompanyId == contact.CompanyId);
                var department = departments.FirstOrDefault(d => d.DepartmentId == contact.DepartmentId);
                
                contact.CompanyName = company?.CompanyName ?? "Unknown";
                contact.DepartmentName = department?.DepartmentName ?? "Unknown";
                
                contacts.Add(contact);
                return contact;
            });
        }

        public async Task<bool> UpdateContact(int id, ContactInfo contact)
        {
            return await Task.Run(() =>
            {
                var existingContact = contacts.FirstOrDefault(c => c.ContactId == id);
                if (existingContact == null)
                    return false;

                // Update properties
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.EmailId = contact.EmailId;
                existingContact.MobileNo = contact.MobileNo;
                existingContact.Designation = contact.Designation;
                existingContact.CompanyId = contact.CompanyId;
                existingContact.DepartmentId = contact.DepartmentId;
                
                // Update CompanyName and DepartmentName
                var company = companies.FirstOrDefault(c => c.CompanyId == contact.CompanyId);
                var department = departments.FirstOrDefault(d => d.DepartmentId == contact.DepartmentId);
                
                existingContact.CompanyName = company?.CompanyName ?? "Unknown";
                existingContact.DepartmentName = department?.DepartmentName ?? "Unknown";
                
                return true;
            });
        }

        public async Task<bool> DeleteContact(int id)
        {
            return await Task.Run(() =>
            {
                var contact = contacts.FirstOrDefault(c => c.ContactId == id);
                if (contact == null)
                    return false;
                    
                return contacts.Remove(contact);
            });
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await Task.Run(() => companies);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await Task.Run(() => departments);
        }
    }
}