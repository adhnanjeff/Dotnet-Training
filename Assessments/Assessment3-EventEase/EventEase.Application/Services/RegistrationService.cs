using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using EventEase.Infrastructure.Repositories;

namespace EventEase.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly RegistrationRepository _registrationRepository;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public RegistrationService(RegistrationRepository registrationRepository, IUserService userService, IEventService eventService)
        {
            _registrationRepository = registrationRepository;
            _userService = userService;
            _eventService = eventService;
        }

        public void AddRegistration(Registration registration)
        {
            var eventExists = _eventService.GetEventById(registration.EventId);
            if (eventExists == null)
                throw new Exception($"Event with ID {registration.EventId} does not exist.");

            var userExists = _userService.GetUserById(registration.UserId);
            if (userExists == null)
                throw new Exception($"User with ID {registration.UserId} does not exist.");

            var alreadyRegistered = _registrationRepository
                .GetAll()
                .Any(r => r.EventId == registration.EventId && r.UserId == registration.UserId);

            if (alreadyRegistered)
                throw new Exception("User is already registered for this event.");

            _registrationRepository.Add(registration);
        }

        public List<Registration> GetAllRegistrations()
        {
            return _registrationRepository.GetAll();
        }

        public List<User> GetUsersWithEventId(int eventId)
        {
            var userIds = _registrationRepository
                .GetAll()
                .Where(r => r.EventId == eventId)
                .Select(r => r.UserId)
                .ToList();

            return _userService.GetAllUsers()
                               .Where(u => userIds.Contains(u.Id))
                               .ToList();
        }
    }
}
