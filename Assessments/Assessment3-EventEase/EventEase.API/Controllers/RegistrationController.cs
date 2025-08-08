using EventEase.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private static readonly List<User> Users = new List<User>
    {
        new User { Id = 1, Name = "Adhnan", Email = "adhnan@example.com" },
        new User { Id = 2, Name = "Subashini", Email = "subashini@example.com" },
        new User { Id = 3, Name = "Sivadarsini", Email = "sivadarsini@example.com" },
        new User { Id = 4, Name = "Ahalya", Email = "ahalya@example.com" },
        new User { Id = 5, Name = "Amrith", Email = "amrith@example.com" }
    };

        private static readonly List<Event> Events = new List<Event>
    {
        new Event { Id = 1, Title = "Beach Volleyball Tournament", Description = "A fun-filled beach volleyball tournament with prizes for the winners.", EventDate = new DateOnly(2025, 8, 15), Location = "Marina Beach" },
        new Event { Id = 2, Title = "Food Festival", Description = "Taste cuisines from all around the world in one place.", EventDate = new DateOnly(2025, 9, 5), Location = "City Central Park" },
        new Event { Id = 3, Title = "Music Concert", Description = "Live performances from top artists and bands.", EventDate = new DateOnly(2025, 10, 20), Location = "Downtown Arena" }
    };

        private static readonly Dictionary<int, List<int>> EventRegistrations = new Dictionary<int, List<int>>
    {
        { 1, new List<int> { 1, 2, 3 } },  // Adhnan, Subashini, Sivadarsini
        { 2, new List<int> { 5 } },       // Amrith
        { 3, new List<int> { 4 } }       // Ahalya
    };

        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpGet("all-events-with-users")]
        public ActionResult<IEnumerable<object>> GetAllEventsWithUsers()
        {
            var result = Events.Select(e => new
            {
                EventId = e.Id,
                Title = e.Title,
                Description = e.Description,
                EventDate = e.EventDate,
                Location = e.Location,
                Users = EventRegistrations.ContainsKey(e.Id)
                    ? Users.Where(u => EventRegistrations[e.Id].Contains(u.Id)).ToList()
                    : new List<User>()
            }).ToList();

            return Ok(result);
        }


        [HttpGet("event/{eventId}")]
        public ActionResult<IEnumerable<User>> GetUsersByEventId(int eventId)
        {
            if (!EventRegistrations.ContainsKey(eventId))
            {
                return NotFound(new { Message = $"No registrations found for Event ID {eventId}." });
            }

            var userIds = EventRegistrations[eventId];
            var registeredUsers = Users.Where(u => userIds.Contains(u.Id)).ToList();

            return Ok(registeredUsers);
        }
    }
}

