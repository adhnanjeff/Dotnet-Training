using EventEase.Core.DTOs;

namespace EventEase.Core.Interfaces
{
    public interface IEventService
    {
        Task<EventResponseDTO> AddEventAsync(EventRequestDTO e);
        Task UpdateEventAsync(int id, EventRequestDTO e);
        Task DeleteEventAsync(int id);
        Task<List<UserResponseDTO>> GetAttendeesByEventIdAsync(int eventId);
        Task<List<EventResponseDTO>> GetAllEventsAsync();
        Task<EventResponseDTO?> GetEventByIdAsync(int id);
    }
}
