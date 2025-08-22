using EventEase.Core.Entities;
using EventEase.Core.Interfaces;


namespace EventEase.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _user = new();

        public async Task AddAsync(User user)
        {
            _user.Add(user);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var user = _user.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _user.Remove(user);
            }
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = _user.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null) { 
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
            await Task.CompletedTask;
        }

        public async Task<User?> GetByIdAsync(int id) { 
            return await Task.FromResult(_user.FirstOrDefault(u => u.Id == id)); 
        }

        public async Task<IEnumerable<User>> GetAllAsync() { 
            return await Task.FromResult(_user); 
        } 
    }
}
