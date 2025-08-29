using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult<User?>(user);
        }

        public Task AddAsync(User entity)
        {
            entity.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(entity);

            return Task.CompletedTask;
        }
        public Task UpdateAsync(User entity)
        {
            var index = _users.FindIndex(u => u.Id == entity.Id);
            if (index != -1)
            {
                _users[index] = entity; 
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }

            return Task.CompletedTask;
        }
    }
}