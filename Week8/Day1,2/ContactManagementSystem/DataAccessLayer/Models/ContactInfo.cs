using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        // Navigation properties (for display only, not mapped to DB)
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
    }
}