using System;
using System.Collections.Generic;
using System.Linq;
using Assessment1_Ecommerce.Models;

namespace Assessment1_Ecommerce.Services
{
    public class UserService : IUserService
    {
        public void RegisterUser(List<User> users, User user)
        {
            if (user == null)
            {
                Console.WriteLine("User cannot be null.");
                return;
            }

            users.Add(user);
            Console.WriteLine($"User {user.Name} registered successfully.");
        }

        public void UpdateUser(List<User> users, int userID)
        {
            var user = users.FirstOrDefault(u => u.Id == userID);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("Enter new name:");
            string? newName = Console.ReadLine();
            user.Name = string.IsNullOrEmpty(newName) ? user.Name : newName;

            Console.WriteLine("Enter new email:");
            string? newEmail = Console.ReadLine();
            user.Email = string.IsNullOrEmpty(newEmail) ? user.Email : newEmail;

            Console.WriteLine("Enter new password:");
            string? newPassword = Console.ReadLine();
            user.Password = string.IsNullOrEmpty(newPassword) ? user.Password : newPassword;

            Console.WriteLine($"User {user.Name} updated successfully.");
        }

        public void DeleteUser(List<User> users, int userID)
        {
            var user = users.FirstOrDefault(u => u.Id == userID);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            users.Remove(user);
            Console.WriteLine($"User {user.Name} deleted successfully.");
        }

        public void DisplayAllUsers(List<User> users)
        {
            if (users == null || users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users)
            {
                user.DisplayUserInfo();
                Console.WriteLine("-------------------------");
            }
        }
    }
}
