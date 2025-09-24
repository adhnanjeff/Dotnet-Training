using System;

namespace TaxiBookingSystem_Phase1.Models
{
    public class Driver : User
    {
        public string LicenseNumber { get; set; }
        public string VehicleDetails { get; set; }
        public Driver(int id, string name, int age, string licenseNumber, string vehicleDetails) : base(id, name, age)
        {
            LicenseNumber = licenseNumber;
            VehicleDetails = vehicleDetails;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Driver ID: {Id}, Name: {Name}, License: {LicenseNumber}, Vehicle: {VehicleDetails}");
        }
    }
}