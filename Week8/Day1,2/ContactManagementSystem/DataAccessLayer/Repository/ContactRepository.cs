using Dapper;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System.Data;

namespace DataAccessLayer.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DapperContext _context;

        public ContactRepository(DapperContext context)
        {
            _context = context;
        }

        // Get all contacts with Company and Department names using JOIN
        public async Task<IEnumerable<ContactInfo>> GetAllContacts()
        {
            var query = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    comp.CompanyName,
                    dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                INNER JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                ORDER BY c.ContactId";

            using (var connection = _context.CreateConnection())
            {
                var contacts = await connection.QueryAsync<ContactInfo>(query);
                return contacts.ToList();
            }
        }

        // Get contact by ID with JOIN
        public async Task<ContactInfo> GetContactById(int id)
        {
            var query = @"
                SELECT 
                    c.ContactId,
                    c.FirstName,
                    c.LastName,
                    c.EmailId,
                    c.MobileNo,
                    c.Designation,
                    c.CompanyId,
                    c.DepartmentId,
                    comp.CompanyName,
                    dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                INNER JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                WHERE c.ContactId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var contact = await connection.QueryFirstOrDefaultAsync<ContactInfo>(query, new { Id = id });
                return contact;
            }
        }

        // Add new contact
        public async Task<int> AddContact(ContactInfo contact)
        {
            var query = @"
                INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId);
                SELECT CAST(SCOPE_IDENTITY() as int)";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, contact);
                return id;
            }
        }

        // Update existing contact
        public async Task<bool> UpdateContact(ContactInfo contact)
        {
            var query = @"
                UPDATE ContactInfo 
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    EmailId = @EmailId,
                    MobileNo = @MobileNo,
                    Designation = @Designation,
                    CompanyId = @CompanyId,
                    DepartmentId = @DepartmentId
                WHERE ContactId = @ContactId";

            using (var connection = _context.CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(query, contact);
                return rowsAffected > 0;
            }
        }

        // Delete contact by ID
        public async Task<bool> DeleteContact(int id)
        {
            var query = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using (var connection = _context.CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }

        // Get all companies for dropdown
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            var query = "SELECT CompanyId, CompanyName FROM Company ORDER BY CompanyName";

            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Company>(query);
                return companies.ToList();
            }
        }

        // Get all departments for dropdown
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var query = "SELECT DepartmentId, DepartmentName FROM Department ORDER BY DepartmentName";

            using (var connection = _context.CreateConnection())
            {
                var departments = await connection.QueryAsync<Department>(query);
                return departments.ToList();
            }
        }
    }
}