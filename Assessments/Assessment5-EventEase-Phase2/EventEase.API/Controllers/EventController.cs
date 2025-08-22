using EventEase.Application.Services;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        // GET: api/Event/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null)
                return NotFound(new { Message = $"Event with ID {id} not found." });

            return Ok(ev);
        }

        // POST: api/Event
        [HttpPost]
        // POST: api/Event
        [HttpPost]
        public async Task<ActionResult> AddEvent(EventRequestDTO ev)
        {
            var createdEvent = await _eventService.AddEventAsync(ev);

            return CreatedAtAction(
                nameof(GetEventById),
                new { id = createdEvent.Id },
                new { Message = "Event created successfully", Event = createdEvent }
            );
        }

        // PUT: api/Event/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, EventRequestDTO ev)
        {
            // since EventRequestDTO doesn’t carry Id, check only against the route param
            await _eventService.UpdateEventAsync(id, ev);
            return Ok(new { Message = "Event updated successfully" });
        }



        // DELETE: api/Event/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return NoContent();
        }

        // GET: api/Event/{id}/attendees
        [HttpGet("{id}/attendees")]
        public async Task<ActionResult<IEnumerable<User>>> GetAttendeesByEventId(int id)
        {
            var attendees = await _eventService.GetAttendeesByEventIdAsync(id);
            return Ok(attendees);
        }
    }
}
