using System;

namespace TaxiBookingSystem_Phase1
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }

        public User(int id, string name, int age)
        {
            Id = id;
            Name = name;
            this.age = age;
        }

        public abstract void DisplayInfo();
    }
}