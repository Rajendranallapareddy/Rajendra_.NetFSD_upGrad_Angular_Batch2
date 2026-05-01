namespace ContactManagementAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }

        // ✅ FIX
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}