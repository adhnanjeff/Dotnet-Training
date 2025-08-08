using EventEase.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private static readonly List<Event> Events = new List<Event>
    {
        new Event
        {
            Id = 1,
            Title = "Beach Volleyball Tournament",
            Description = "A fun-filled beach volleyball tournament with prizes for the winners.",
            EventDate = new DateOnly(2025, 8, 15),
            Location = "Marina Beach"
        },
        new Event
        {
            Id = 2,
            Title = "Food Festival",
            Description = "Taste cuisines from all around the world in one place.",
            EventDate = new DateOnly(2025, 9, 5),
            Location = "City Central Park"
        },
        new Event
        {
            Id = 3,
            Title = "Music Concert",
            Description = "Live performances from top artists and bands.",
            EventDate = new DateOnly(2025, 10, 20),
            Location = "Downtown Arena"
        }
    };

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        // GET: /Event
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAllEvents()
        {
            return Ok(Events);
        }

        // GET: /Event/{id}
        [HttpGet("{id}")]
        public ActionResult<Event> GetEventById(int id)
        {
            var ev = Events.FirstOrDefault(e => e.Id == id);
            if (ev == null)
            {
                return NotFound(new { Message = $"Event with ID {id} not found." });
            }
            return Ok(ev);
        }
    }
}
