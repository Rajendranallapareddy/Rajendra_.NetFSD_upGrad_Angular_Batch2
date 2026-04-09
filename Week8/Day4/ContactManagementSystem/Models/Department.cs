using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        // Navigation property
        public virtual ICollection<ContactInfo> Contacts { get; set; }
    }
}