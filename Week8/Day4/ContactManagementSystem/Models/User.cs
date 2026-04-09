using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } // "Admin" or "User"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}