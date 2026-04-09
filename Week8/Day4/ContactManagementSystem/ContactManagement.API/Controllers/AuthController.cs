using Microsoft.AspNetCore.Mvc;
using ContactManagement.DAL.Models;
using ContactManagement.DAL.Repository;
using ContactManagement.API.Helpers;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthController(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Check if user already exists
            if (await _userRepository.UserExists(request.Username, request.Email))
                return BadRequest(new { message = "Username or Email already exists" });

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Role = request.Role ?? "User" // Default role is "User"
            };

            var createdUser = await _userRepository.RegisterUser(user, request.Password);

            return Ok(new { 
                message = "User registered successfully", 
                userId = createdUser.UserId,
                username = createdUser.Username,
                role = createdUser.Role
            });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find user by username
            var user = await _userRepository.GetUserByUsername(request.Username);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            // Verify password (using simple hash comparison)
            if (!VerifyPassword(request.Password, user.PasswordHash))
                return Unauthorized(new { message = "Invalid username or password" });

            // Generate JWT token
            var token = _jwtHelper.GenerateToken(user.Username, user.Email, user.Role);

            return Ok(new
            {
                message = "Login successful",
                token = token,
                username = user.Username,
                email = user.Email,
                role = user.Role
            });
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Simple hash comparison (in production, use proper password hashing like BCrypt)
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var computedHash = System.Convert.ToBase64String(hashedBytes);
                return computedHash == passwordHash;
            }
        }
    }

    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; } // Admin or User
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}