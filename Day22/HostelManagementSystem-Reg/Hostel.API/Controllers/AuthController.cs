using Hostel.Core.DTOs;
using Hostel.Core.Entities;
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
        private readonly IConfiguration _config;
        private static List<User> _users = new(); // In-memory user store (for demo purposes, replace with a database in production)
        private readonly PasswordHasher<User> _passwordHasher = new();

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationRequestDTO registerRequestDTO)
        {
            // ✅ Check if user already exists
            if (_users.Any(u => u.Username == registerRequestDTO.Username))
            {
                return BadRequest(new { Message = "User already exists" });
            }

            var user = new User
            {
                Username = registerRequestDTO.Username,
                Password = registerRequestDTO.Password
            };

            // ✅ Hash the password before storing
            user.PasswordHash = _passwordHasher.HashPassword(user, registerRequestDTO.Password);

            _users.Add(user);

            return Ok(new { Message = "User registered successfully" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = _users.FirstOrDefault(u => u.Username == loginRequestDTO.Username);

            if (user == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            // ✅ Verify hashed password
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequestDTO.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized(new { Message = "Invalid credentials" });

            // ✅ Generate JWT with expiration
            var (token, expiration) = GenerateJwtToken(user.Username);

            return Ok(new
            {
                Token = token,
                ExpiresAt = expiration
            });
        }

        private (string Token, DateTime Expiration) GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin") // Example role
            };

            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"]));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
        }
    }
}
