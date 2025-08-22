using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventResponseDTO> AddEventAsync(EventRequestDTO dto)
        {
            var allEvents = await _eventRepository.GetAllAsync();

            int nextId = allEvents.Any()
                ? allEvents.Max(e => e.Id) + 1
                : 1;

            var newEvent = new Event
            {
                Id = nextId,
                Title = dto.Title,
                Description = dto.Desc,
                EventDate = dto.EventDate,
                Location = dto.Location
            };

            await _eventRepository.AddAsync(newEvent);

            return MapToResponseDTO(newEvent);
        }


        public async Task UpdateEventAsync(int id, EventRequestDTO dto)
        {
            var updatedEvent = new Event
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Desc,
                EventDate = dto.EventDate,
                Location = dto.Location
            };

            await _eventRepository.UpdateAsync(updatedEvent);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _eventRepository.DeleteAsync(id);
        }

        public async Task<List<EventResponseDTO>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();

            return events.Select(MapToResponseDTO).ToList();
        }

        public async Task<EventResponseDTO?> GetEventByIdAsync(int id)
        {
            var e = await _eventRepository.GetByIdAsync(id);
            return e == null ? null : MapToResponseDTO(e);
        }

        public async Task<List<UserResponseDTO>> GetAttendeesByEventIdAsync(int eventId)
        {
            var attendees = await _eventRepository.GetAttendeesByEventIdAsync(eventId);

            return attendees.Select(u => new UserResponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Events = u.EventsParticipating?.Select(e => e.Title).ToList() ?? new List<string>()
            }).ToList();
        }

        private static EventResponseDTO MapToResponseDTO(Event e)
        {
            return new EventResponseDTO
            {
                Id = e.Id,
                Title = e.Title,
                Desc = e.Description,
                EventDate = e.EventDate,
                Location = e.Location,
                Participants = e.Participants?.Select(u => u.Name).ToList() ?? new List<string>()
            };
        }
    }
}
