using Assessment2_BugTrackerLite.Models;

namespace Assessment2_BugTrackerLite.Services
{
    public interface IUserService
    {
        void CreateUser(string userName);
        List<User> GetAllUsers();
        User GetUserById(int userId);
    }
}
