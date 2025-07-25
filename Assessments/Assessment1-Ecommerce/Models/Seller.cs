using System;
using System.Collections.Generic;
using Assessment1_Ecommerce.Models;

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

        public void SellerPortal()
        {
            Console.WriteLine($"\nWelcome to the Seller Portal, {Name}!");
            bool continuePortal = true;

            while (continuePortal)
            {
                Console.WriteLine("\n1. View Listed Products");
                Console.WriteLine("2. Add New Product");
                Console.WriteLine("3. Exit Seller Portal");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (ListedProducts.Count == 0)
                        {
                            Console.WriteLine("You have no listed products.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Your Listed Products ---");
                            foreach (var product in ListedProducts)
                            {
                                product.DisplayProductInfo();
                            }
                        }
                        break;

                    case "2":
                        AddNewProduct();
                        break;

                    case "3":
                        continuePortal = false;
                        Console.WriteLine("Exiting Seller Portal...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddNewProduct()
        {
            Console.WriteLine("\nSelect type of product to add:");
            Console.WriteLine("1. Electronics");
            Console.WriteLine("2. Clothing");
            Console.WriteLine("3. Home Goods");

            Console.Write("Enter choice: ");
            string? typeChoice = Console.ReadLine();

            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter Product Name: ");
            string? name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string? description = Console.ReadLine();
            Console.Write("Enter Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price.");
                return;
            }
            Console.Write("Enter Stock Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stockQuantity))
            {
                Console.WriteLine("Invalid stock quantity.");
                return;
            }

            Product? newProduct = null;

            switch (typeChoice)
            {
                case "1": // Electronics
                    Console.Write("Enter Brand: ");
                    string? brand = Console.ReadLine();
                    Console.Write("Enter Model: ");
                    string? model = Console.ReadLine();
                    Console.Write("Enter Warranty Period: ");
                    string? warranty = Console.ReadLine();
                    if (brand == null || model == null || warranty == null)
                    {
                        Console.WriteLine("All fields are required.");
                        return;
                    }
                    newProduct = new Electronics(productId, name ?? "", description ?? "", price, stockQuantity, brand, model, warranty);
                    break;

                case "2": // Clothing
                    Console.Write("Enter Size: ");
                    string? size = Console.ReadLine();
                    Console.Write("Enter Color: ");
                    string? color = Console.ReadLine();
                    if (size == null || color == null)
                    {
                        Console.WriteLine("All fields are required.");
                        return;
                    }
                    newProduct = new Clothing(productId, name ?? "", description ?? "", price, stockQuantity, size, color);
                    break;

                case "3": // Home Goods
                    Console.Write("Enter Category: ");
                    string? category = Console.ReadLine();
                    Console.Write("Enter Material: ");
                    string? material = Console.ReadLine();
                    if (category == null || material == null)
                    {
                        Console.WriteLine("All fields are required.");
                        return;
                    }
                    newProduct = new HomeGoods(productId, name ?? "", description ?? "", price, stockQuantity, category, material);
                    break;

                default:
                    Console.WriteLine("Invalid product type selection.");
                    return;
            }

            if (newProduct != null)
            {
                ListedProducts.Add(newProduct);
                Console.WriteLine($"Product '{newProduct.Name}' added successfully.");
            }
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
