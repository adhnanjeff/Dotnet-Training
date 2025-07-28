<<<<<<< Updated upstream
=======
﻿// Program.cs
>>>>>>> Stashed changes
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
            List<Seller> sellers = new List<Seller>();

            UserService userService = new UserService();
            ProductService productService = new ProductService();

            while (true)
            {
                Console.WriteLine("\nWelcome to the E-commerce System! Please choose an option:\n" +
                    "1. Register as Buyer\n" +
                    "2. Register as Seller\n" +
<<<<<<< Updated upstream
                    "3. Delete User\n" +
                    "4. Update User\n" +
                    "5. View All Users\n" +
                    "6. Buyer Portal\n" +
                    "7. Seller Portal\n" +
                    "8. Exit"
                );
=======
                    "3. Login as Buyer\n" +
                    "4. View All Users\n" +
                    "5. Exit");
>>>>>>> Stashed changes

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter ID: ");
<<<<<<< Updated upstream
                        if (!int.TryParse(Console.ReadLine(), out int buyerId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

=======
                        int.TryParse(Console.ReadLine(), out int buyerId);
>>>>>>> Stashed changes
                        Console.Write("Enter Name: ");
                        string? buyerName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string? buyerEmail = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string? buyerPassword = Console.ReadLine();
                        Console.Write("Enter Shipping Address: ");
                        string? shipping = Console.ReadLine();
                        Buyer buyer = new Buyer(buyerId, buyerName!, buyerEmail!, buyerPassword!, shipping!);
                        users.Add(buyer);
                        break;

                    case "2":
                        Console.Write("Enter ID: ");
<<<<<<< Updated upstream
                        if (!int.TryParse(Console.ReadLine(), out int sellerId))
                        {
                            Console.WriteLine("Invalid ID.");
                            break;
                        }

=======
                        int.TryParse(Console.ReadLine(), out int sellerId);
>>>>>>> Stashed changes
                        Console.Write("Enter Name: ");
                        string? sellerName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string? sellerEmail = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        string? sellerPassword = Console.ReadLine();
                        Console.Write("Enter Store Name: ");
                        string? sellerStore = Console.ReadLine();
                        Seller seller = new Seller(sellerId, sellerName!, sellerEmail!, sellerPassword!, sellerStore!);
                        sellers.Add(seller);
                        users.Add(seller);
                        break;

                    case "3":
                        Console.Write("Enter your Email: ");
                        string? loginEmail = Console.ReadLine();
                        User? foundUser = users.Find(u => u.Email == loginEmail);
                        if (foundUser is Buyer loggedInBuyer)
                        {
                            loggedInBuyer.BuyerPortal(sellers);
                        }
                        else
                        {
                            Console.WriteLine("Buyer not found or incorrect user type.");
                        }
                        break;

                    case "4":
                        foreach (var user in users)
                        {
                            user.DisplayUserInfo();
                        }
                        break;

                    case "5":
<<<<<<< Updated upstream
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
=======
                        Console.WriteLine("Exiting system. Goodbye!");
>>>>>>> Stashed changes
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
