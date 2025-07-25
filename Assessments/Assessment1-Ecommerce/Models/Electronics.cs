using System;

namespace Assessment1_Ecommerce.Models
{
    public class Electronics : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string WarrantyPeriod { get; set; }
        public Electronics(int id, string name, string description, decimal price, int stockQuantity, string brand, string model, string warrantyPeriod)
            : base(id, name, description, price, stockQuantity)
        {
            Brand = brand;
            Model = model;
            WarrantyPeriod = warrantyPeriod;
        }
        public override void DisplayProductInfo()
        {
            //Console.WriteLine("------ Electronics Info ------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Warranty Period: {WarrantyPeriod}");
            Console.WriteLine($"Stock Quantity: {StockQuantity}");
            Console.WriteLine("---------------------------------");
        }
    }
}