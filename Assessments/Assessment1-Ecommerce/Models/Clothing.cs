using System;

namespace Assessment1_Ecommerce.Models
{
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public Clothing(int id, string name, string description, decimal price, int stockQuantity, string size, string color)
            : base(id, name, description, price, stockQuantity)
        {
            Size = size;
            Color = color;
        }

        public override void DisplayProductInfo()
        {
            //Console.WriteLine("------ Clothing Info ------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Stock Quantity: {StockQuantity}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine("---------------------------------");
        }
    }
}