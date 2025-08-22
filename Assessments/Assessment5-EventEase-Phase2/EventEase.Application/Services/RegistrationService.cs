using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public RegistrationService(
            IRegistrationRepository registrationRepository,
            IUserService userService,
            IEventService eventService)
        {
            _registrationRepository = registrationRepository;
            _userService = userService;
            _eventService = eventService;
        }

        public async Task<RegisterationResponseDTO> AddRegistrationAsync(RegistrationRequestDTO registrationDto)
        {
            // ✅ Check event existence
            var eventExists = await _eventService.GetEventByIdAsync(registrationDto.EventId);
            if (eventExists == null)
                throw new Exception($"Event with ID {registrationDto.EventId} does not exist.");

            // ✅ Check user existence
            var userExists = await _userService.GetUserByIdAsync(registrationDto.UserId);
            if (userExists == null)
                throw new Exception($"User with ID {registrationDto.UserId} does not exist.");

            // ✅ Prevent duplicate registrations
            var allRegistrations = await _registrationRepository.GetAllAsync();
            var alreadyRegistered = allRegistrations
                .Any(r => r.EventId == registrationDto.EventId && r.UserId == registrationDto.UserId);

            if (alreadyRegistered)
                throw new Exception("User is already registered for this event.");

            // ✅ Generate next Id
            int nextId = allRegistrations.Any()
                ? allRegistrations.Max(r => r.Id) + 1
                : 1;

            // ✅ Map DTO -> Entity
            var registration = new Registration
            {
                Id = nextId,
                UserId = registrationDto.UserId,
                EventId = registrationDto.EventId,
                RegDate = registrationDto.RegDate
            };

            await _registrationRepository.AddAsync(registration);

            // ✅ Return response DTO with Id
            return new RegisterationResponseDTO
            {
                Id = registration.Id, // add Id in DTO
                UserId = registration.UserId,
                EventId = registration.EventId,
                DateTime = registration.RegDate
            };
        }


        public async Task<List<RegisterationResponseDTO>> GetAllRegistrationsAsync()
        {
            var registrations = await _registrationRepository.GetAllAsync();

            // ✅ Map Entity -> DTO
            return registrations.Select(r => new RegisterationResponseDTO
            {
                UserId = r.UserId,
                EventId = r.EventId,
                DateTime = r.RegDate
            }).ToList();
        }

        public async Task<RegisterationResponseDTO?> GetRegistrationByIdAsync(int id)
        {
            var registration = await _registrationRepository.GetByIdAsync(id);
            if (registration == null) return null;

            // ✅ Map Entity -> DTO
            return new RegisterationResponseDTO
            {
                UserId = registration.UserId,
                EventId = registration.EventId,
                DateTime = registration.RegDate
            };
        }

        public async Task DeleteRegistration(int id)
        {
            var registration = await _registrationRepository.GetByIdAsync(id);
            if (registration == null)
                throw new Exception($"Registration with ID {id} does not exist.");

            await _registrationRepository.DeleteAsync(id);
        }
    }
}
