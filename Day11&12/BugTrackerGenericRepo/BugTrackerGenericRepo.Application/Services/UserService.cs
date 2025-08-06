using BugTrackerGenericRepo.Core.Entities;
using BugTrackerGenericRepo.Core.Interfaces;


namespace BugTrackerGenericRepo.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _userRepository.Add(user);
        }
        public void UpdateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _userRepository.Update(user);
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        public User? GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
