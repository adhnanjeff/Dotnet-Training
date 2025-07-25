using System;
using System.Collections.Generic;

namespace Assessment1_Ecommerce.Models
{
    public class Seller : User
    {
        public string StoreName { get; set; }
        public List<Product> ListedProducts { get; set; }
        public List<Product> SoldProducts { get; set; }

        public Seller(int id, string name, string email, string password, string storeName)
            : base(id, name, email, password)
        {
            StoreName = storeName;
            ListedProducts = new List<Product>();
            SoldProducts = new List<Product>();
        }

        public override void DisplayUserInfo()
        {
            Console.WriteLine("------ Seller Info ------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Store Name: {StoreName}");
            Console.WriteLine("-------------------------");
        }
    }
}