using System.Collections.Generic;
using Assessment1_Ecommerce.Models;

namespace Assessment1_Ecommerce.Services
{
    public interface IUserService
    {
        void RegisterUser(List<User> users, User user);
        void UpdateUser(List<User> users, int userID);
        void DeleteUser(List<User> users, int userID);
        void DisplayAllUsers(List<User> users);
    }
}