using System;

namespace Assessment1_Ecommerce.Models
{
    public class HomeGoods : Product
    {
        public string Category { get; set; }
        public string Material { get; set; }


        public HomeGoods(int id, string name, string description, decimal price, int stockQuantity, string category, string material)
            : base(id, name, description, price, stockQuantity)
        {
            Category = category;
            Material = material;
        }
        public override void DisplayProductInfo()
        {
            //Console.WriteLine("------ Home Goods Info ------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Material: {Material}");
            Console.WriteLine($"Stock Quantity: {StockQuantity}");
            Console.WriteLine("---------------------------------");
        }
    }
}