using EventEase.Core.Entities;
using EventEase.Core.Interfaces;


namespace EventEase.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly List<Registration> _register = new();

        public async Task AddAsync(Registration reg)
        {
            _register.Add(reg);
            await Task.CompletedTask;
        }

        public async Task<Registration?> GetByIdAsync(int id) {
            return await Task.FromResult(_register.FirstOrDefault(r => r.Id == id));
        }

        public async Task<IEnumerable<Registration>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<Registration>>(_register);
        }

        public async Task DeleteAsync(int id)
        {
            var reg = _register.FirstOrDefault(r => r.Id == id);
            if(reg != null)
            {
                _register.Remove(reg);
            }
            await Task.CompletedTask;
        }
    }
}
