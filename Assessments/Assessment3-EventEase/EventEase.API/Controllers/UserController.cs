using EventEase.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
        {
        new User { Id = 1, Name = "Adhnan", Email = "adhnan@example.com" },
        new User { Id = 2, Name = "Subashini", Email = "subashini@example.com" },
        new User { Id = 3, Name = "Sivadarsini", Email = "sivadarsini@example.com" },
        new User { Id = 4, Name = "Ahalya", Email = "ahalya@example.com" },
        new User { Id = 5, Name = "Amrith", Email = "amrith@example.com" }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        // GET: /User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return Ok(Users);
        }

        // GET: /User/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }
            return Ok(user);
        }
    }
}
