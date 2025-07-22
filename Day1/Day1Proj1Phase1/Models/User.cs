using System;

namespace Day1Proj1Phase1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public static void DisplayUser(User user)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Role: {user.Role}");
        }
    }
}
