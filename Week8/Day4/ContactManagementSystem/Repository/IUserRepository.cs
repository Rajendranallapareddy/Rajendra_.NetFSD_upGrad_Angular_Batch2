using ContactManagement.DAL.Models;

namespace ContactManagement.DAL.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserByEmail(string email);
        Task<User> RegisterUser(User user, string password);
        Task<bool> UserExists(string username, string email);
    }
}