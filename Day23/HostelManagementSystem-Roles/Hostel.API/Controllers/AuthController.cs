using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hostel.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> _users = new(); // In-memory user store (for demo purposes, replace with a database in production)
        private readonly IConfiguration _config;
        private readonly PasswordHasher<User> _passwordHasher = new();
        private readonly IStaffService _staffService;

        public AuthController(IConfiguration config, IStaffService staffService)
        {
            _staffService = staffService;
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            // ✅ Check if user already exists
            if (_users.Any(u => u.Username == registerRequestDTO.Username))
            {
                return BadRequest(new { Message = "User already exists" });
            }

            var user = new User
            {
                Username = registerRequestDTO.Username,
                Password = registerRequestDTO.Password,
                Role = registerRequestDTO.Role
            };

            // ✅ Hash the password before storing
            user.PasswordHash = _passwordHasher.HashPassword(user, registerRequestDTO.Password);

            _users.Add(user);
            if(user.Role == "Staff")
            {
                _staffService.CreateStaff(new StaffRequestDTO { 
                    Name = registerRequestDTO.Username,
                    Password = registerRequestDTO.Password
                });
            }

            return Ok(new { Message = "User registered successfully\n", Role = user.Role });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            // ✅ Dummy validation (replace with DB check or UserService)
            if (loginRequestDTO.Username == "admin" && loginRequestDTO.Password == "pass")
            {
                var token = GenerateJwtToken(loginRequestDTO.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid credentials" });
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // ✅ Add claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin") // Example role
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
