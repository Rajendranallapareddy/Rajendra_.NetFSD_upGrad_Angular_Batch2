using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactInfo> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships using Fluent API
            // One Company → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // One Department → Many Contacts
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Contacts)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Companies
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, CompanyName = "ABC Infotech" },
                new Company { CompanyId = 2, CompanyName = "XYZ Solutions" },
                new Company { CompanyId = 3, CompanyName = "Tech Innovations" },
                new Company { CompanyId = 4, CompanyName = "Digital Dynamics" }
            );

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" },
                new Department { DepartmentId = 4, DepartmentName = "Marketing" },
                new Department { DepartmentId = 5, DepartmentName = "Sales" }
            );

            // Seed Sample Contacts
            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo
                {
                    ContactId = 1,
                    FirstName = "Rahul",
                    LastName = "Sharma",
                    EmailId = "rahul.sharma@abc.com",
                    MobileNo = 9876543210,
                    Designation = "Software Engineer",
                    CompanyId = 1,
                    DepartmentId = 1
                },
                new ContactInfo
                {
                    ContactId = 2,
                    FirstName = "Priya",
                    LastName = "Patel",
                    EmailId = "priya.patel@xyz.com",
                    MobileNo = 9876543211,
                    Designation = "Project Manager",
                    CompanyId = 2,
                    DepartmentId = 1
                },
                new ContactInfo
                {
                    ContactId = 3,
                    FirstName = "Amit",
                    LastName = "Verma",
                    EmailId = "amit.verma@tech.com",
                    MobileNo = 9876543212,
                    Designation = "Senior Developer",
                    CompanyId = 3,
                    DepartmentId = 1
                }
            );
        }
    }
}