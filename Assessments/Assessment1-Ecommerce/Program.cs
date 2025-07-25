using System;
using System.Collections.Generic;
using System.Linq;
using Assessment1_Ecommerce.Models;
using Assessment1_Ecommerce.Services;

namespace Assessment1_Ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            UserService userService = new UserService();

            while (true)
            {
                Console.WriteLine(
                    "\nWelcome to the E-commerce System! Please choose an option:\n" +
                    "1. Register as Buyer\n" +
                    "2. Register as Seller\n" +
                    "3. Delete User\n" +
                    "4. Update User\n" +
                    "5. View All Users\n" +
                    "6. Buyer Portal\n" +
                    "7. Seller Portal\n" +
                    "8. Exit"
                );

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Registering as Buyer...");
                        Console.Write("Enter ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int buyerId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

                        Console.Write("Enter Name: ");
                        string? buyerName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string? buyerEmail = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string? buyerPassword = Console.ReadLine();
                        Console.Write("Enter Shipping Address: ");
                        string? shippingAddress = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(buyerName) ||
                            string.IsNullOrWhiteSpace(buyerEmail) ||
                            string.IsNullOrWhiteSpace(buyerPassword) ||
                            string.IsNullOrWhiteSpace(shippingAddress))
                        {
                            Console.WriteLine("All fields are required.");
                            break;
                        }

                        Buyer buyer = new Buyer(buyerId, buyerName, buyerEmail, buyerPassword, shippingAddress);
                        userService.RegisterUser(users, buyer);
                        break;

                    case "2":
                        Console.WriteLine("Registering as Seller...");
                        Console.Write("Enter ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int sellerId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

                        Console.Write("Enter Name: ");
                        string? sellerName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string? sellerEmail = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string? sellerPassword = Console.ReadLine();
                        Console.Write("Enter Store Name: ");
                        string? storeName = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(sellerName) ||
                            string.IsNullOrWhiteSpace(sellerEmail) ||
                            string.IsNullOrWhiteSpace(sellerPassword) ||
                            string.IsNullOrWhiteSpace(storeName))
                        {
                            Console.WriteLine("All fields are required.");
                            break;
                        }

                        Seller seller = new Seller(sellerId, sellerName, sellerEmail, sellerPassword, storeName);
                        userService.RegisterUser(users, seller);
                        break;

                    case "3":
                        Console.Write("Enter User ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            userService.DeleteUser(users, deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter User ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            userService.UpdateUser(users, updateId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "5":
                        userService.DisplayAllUsers(users);
                        break;

                    case "6":
                        // Buyer portal
                        var buyerUsers = users.OfType<Buyer>().ToList();
                        if (buyerUsers.Count == 0)
                        {
                            Console.WriteLine("No buyers registered.");
                            break;
                        }

                        Console.WriteLine("Select Buyer by ID to enter portal:");
                        foreach (var b in buyerUsers)
                        {
                            Console.WriteLine($"ID: {b.Id}, Name: {b.Name}");
                        }
                        Console.Write("Enter Buyer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int buyerPortalId))
                        {
                            Buyer? buyerUser = buyerUsers.FirstOrDefault(b => b.Id == buyerPortalId);
                            if (buyerUser != null)
                            {
                                var sellerUsers = users.OfType<Seller>().ToList();
                                buyerUser.BuyerPortal(sellerUsers);
                            }
                            else
                            {
                                Console.WriteLine("Buyer not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "7":
                        // Seller portal
                        var sellerUsersList = users.OfType<Seller>().ToList();
                        if (sellerUsersList.Count == 0)
                        {
                            Console.WriteLine("No sellers registered.");
                            break;
                        }

                        Console.WriteLine("Select Seller by ID to enter portal:");
                        foreach (var s in sellerUsersList)
                        {
                            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
                        }
                        Console.Write("Enter Seller ID: ");
                        if (int.TryParse(Console.ReadLine(), out int sellerPortalId))
                        {
                            Seller? sellerUser = sellerUsersList.FirstOrDefault(s => s.Id == sellerPortalId);
                            if (sellerUser != null)
                            {
                                sellerUser.SellerPortal();
                            }
                            else
                            {
                                Console.WriteLine("Seller not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "8":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
