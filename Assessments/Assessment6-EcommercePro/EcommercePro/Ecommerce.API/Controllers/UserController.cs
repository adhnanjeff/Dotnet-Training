using Ecommerce.Core.DTOs;
using Ecommerce.Core.DTOs.Ecommerce.Core.DTOs;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 Require JWT authentication for all endpoints
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // 🔐 Only Admin can view all users
        public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // 🔐 Only Admin can create users
        public async Task<ActionResult<UserResponseDTO>> Create(UserRequestDTO user)
        {
            var createdUser = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // 🔐 Only Admin can update users
        public async Task<IActionResult> Update(int id, UserRequestDTO user)
        {
            try
            {
                await _userService.UpdateUserAsync(id, user);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // 🔐 Only Admin can delete users
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
