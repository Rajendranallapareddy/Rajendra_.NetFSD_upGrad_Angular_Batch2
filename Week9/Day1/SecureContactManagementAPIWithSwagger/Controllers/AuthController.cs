using Microsoft.AspNetCore.Mvc;
using ContactManagementAPI.Data;
using ContactManagementAPI.Models;
using ContactManagementAPI.Services;

namespace ContactManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserInfo user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public IActionResult Login(UserInfo login)
        {
            var user = _context.Users.FirstOrDefault(x =>
                x.EmailId == login.EmailId && x.Password == login.Password);

            if (user == null)
                return Unauthorized();

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}