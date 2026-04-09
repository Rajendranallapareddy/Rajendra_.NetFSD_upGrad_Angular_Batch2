using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        // Navigation property
        public virtual ICollection<ContactInfo> Contacts { get; set; }
    }
}