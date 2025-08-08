

using EventEase.Core.Entities;

namespace EventEase.Core.Interfaces
{
    public interface IUserService
    {
        void AddUser(User e);
        void UpdateUser(User e);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
