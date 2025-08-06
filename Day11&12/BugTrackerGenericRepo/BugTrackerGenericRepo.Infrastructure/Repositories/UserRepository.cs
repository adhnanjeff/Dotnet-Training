using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;

namespace BugTrackerGenericRepo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void Add(User entity)
        {
            entity.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(entity);
        }
        public void Update(User entity)
        {
            var existingUser = GetById(entity.Id);
            if (existingUser != null)
            {
                existingUser.Username = entity.Username;
                existingUser.Email = entity.Email;
                existingUser.Role = entity.Role;
            }
        }
        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
        public User? GetById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        public List<User> GetAll()
        {
            return new List<User>(_users);
        }
    }
}
