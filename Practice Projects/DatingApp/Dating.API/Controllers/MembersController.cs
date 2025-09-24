using Dating.API.Data;
using Dating.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Dating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext appDbContext) : ControllerBase // localhost:5001/api/members
    {
        // With Async programming, we can free up the thread to do other work while waiting for I/O operations to complete
        // Eg: Waiter takes order -> while waiting for food, he can take other orders -> food is ready, serve food
        // This is especially useful in web applications where there are many concurrent requests
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetUsers()
        {
            var users = await appDbContext.Users.ToListAsync();
            return Ok(users);
        }

        // Non-Async Eg: Waiter takes order -> waits for food to be prepared -> serves food
        // Does not take other orders in the meantime/waiting time
        [HttpGet("{id}")]                                                      // localhost:5001/api/members/{jeff-id}
        public ActionResult<AppUser> GetUser(string id)
        {
            var user = appDbContext.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
