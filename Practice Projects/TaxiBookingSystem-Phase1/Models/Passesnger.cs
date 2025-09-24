using System;

namespace TaxiBookingSystem_Phase1.Models
{
    public class Passenger : User
    {
        public string PhoneNumber { get; set; }
        public Passenger(int id, string name, int age, string phoneNumber) : base(id, name, age)
        {
            PhoneNumber = phoneNumber;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Passenger ID: {Id}, Name: {Name}, Phone: {PhoneNumber}");
        }
    }
}