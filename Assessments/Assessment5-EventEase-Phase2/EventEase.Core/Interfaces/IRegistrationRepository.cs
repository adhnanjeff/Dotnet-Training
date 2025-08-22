

using EventEase.Core.Entities;

namespace EventEase.Core.Interfaces
{
    public interface IRegistrationRepository
    {
        Task AddAsync(Registration reg);
        Task<Registration?> GetByIdAsync(int id);
        Task<IEnumerable<Registration>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
