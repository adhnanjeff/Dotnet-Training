using System;
using System.Collections.Generic;
using System.Linq;
using Assessment2_BugTrackerLite.Data;
using Assessment2_BugTrackerLite.Models;

namespace Assessment2_BugTrackerLite.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(string userName)
        {
            var user = new User { UserName = userName };
            _context.Users.Add(user);
            _context.SaveChanges();
            Console.WriteLine($"User '{userName}' created successfully.");
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
