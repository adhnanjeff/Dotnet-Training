

using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _user = new();

        public void Add(User user)
        {
            _user.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _user.Remove(user);
            }
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser != null) { 
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public User? GetById(int id) => _user.FirstOrDefault(u => u.Id == id);

        public List<User> GetAll() => _user;
        
    }
}
