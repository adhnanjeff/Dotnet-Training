using EventEase.Core.Entities;
using EventEase.Core.Interfaces;


namespace EventEase.Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _userService;

        public UserServices(IUserRepository user)
        {
            _userService = user;
        }
        public void AddUser(User e)
        {
            _userService.Add(e);
        }

        public void UpdateUser(User e)
        {
            _userService.Update(e);
        }

        public void DeleteUser(int id)
        {
            _userService.Delete(id);
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userService.GetById(id);
        }
    }
}
