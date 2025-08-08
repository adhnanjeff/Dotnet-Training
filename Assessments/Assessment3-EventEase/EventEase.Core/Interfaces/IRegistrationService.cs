using EventEase.Core.Entities;

namespace EventEase.Core.Interfaces
{
    public interface IRegistrationService
    {
        void AddRegistration(Registration registration);
        List<Registration> GetAllRegistrations();
        List<User> GetUsersWithEventId(int eventId);
    }
}
