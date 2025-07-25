using System;

using Assessment1_Ecommerce.Services;

namespace Assessment1_Ecommerce.Models
{
    public class Buyer : User
    {
        public string ShippingAddress { get; set; }
        public List<Product> Cart { get; set; }
        public List<Product> Bought { get; set; }

        public Buyer(int id, string name, string email, string password, string shippingAddress)
            : base(id, name, email, password)
        {
            ShippingAddress = shippingAddress;
            Cart = new List<Product>();
            Bought = new List<Product>();
        }

        public void BuyerPortal(List<Seller> allSellers)
        {
            ProductService productService = new ProductService();
            Console.WriteLine("Welcome to the Buyer Portal!");
            Console.WriteLine("You can add products to your cart and purchase them.");
            bool continueShopping = true;

            while (continueShopping)
            {
                Console.WriteLine("\n1. View all products");
                Console.WriteLine("2. Add product to cart");
                Console.WriteLine("3. Buy product from cart");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- All Available Products ---");
                        var allProducts = productService.GetAllProductsFromSellers(allSellers);
                        productService.DisplayAllProducts(allProducts);
                        break;

                    case "2":
                        Console.Write("Enter Product ID to add to cart: ");
                        if (int.TryParse(Console.ReadLine(), out int addId))
                        {
                            var productToAdd = productService.FindProductById(
                                productService.GetAllProductsFromSellers(allSellers), addId);
                            if (productToAdd != null)
                            {
                                AddToCart(productToAdd);
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID input.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Product ID to purchase: ");
                        if (int.TryParse(Console.ReadLine(), out int buyId))
                        {
                            var productToBuy = Cart.FirstOrDefault(p => p.Id == buyId);
                            if (productToBuy != null)
                            {
                                BuyProduct(productToBuy);
                            }
                            else
                            {
                                Console.WriteLine("Product not found in cart.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID input.");
                        }
                        break;

                    case "4":
                        continueShopping = false;
                        Console.WriteLine("Exiting Buyer Portal.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void AddToCart(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            Cart.Add(product);
            Console.WriteLine($"Product '{product.Name}' added to cart.");
        }

        public void BuyProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }
            if (!Cart.Contains(product))
            {
                throw new InvalidOperationException("Product not in cart.");
            }
            Cart.Remove(product);
            Bought.Add(product);
            Console.WriteLine($"Product '{product.Name}' purchased successfully.");
        }
        public override void DisplayUserInfo()
        {
            Console.WriteLine("------ Buyer Info ------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Shipping Address: {ShippingAddress}");
            Console.WriteLine("-------------------------");
        }
    }
}
