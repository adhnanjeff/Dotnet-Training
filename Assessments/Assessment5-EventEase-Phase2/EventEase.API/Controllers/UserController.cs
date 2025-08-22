using EventEase.Application.Services;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> AddUser(UserRequestDTO user)
        {
            var createdUser = await _userService.AddUserAsync(user);

            return CreatedAtAction(
                nameof(GetUserById),
                new { id = createdUser.Id },
                new { Message = "User created successfully", User = createdUser }
            );
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserRequestDTO user)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);

            if (existingUser == null)
                return NotFound(new { Message = $"User with Id {id} not found" });

            await _userService.UpdateUserAsync(id, user);

            return Ok(new { Message = $"User with Id {id} updated successfully" });
        }


        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
