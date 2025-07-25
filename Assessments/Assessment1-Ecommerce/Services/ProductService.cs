using System;
using System.Collections.Generic;
using System.Linq;
using Assessment1_Ecommerce.Models;

namespace Assessment1_Ecommerce.Services
{
    public class ProductService : IProductService
    {
        public List<Product> GetAllProductsFromSellers(List<Seller> sellers)
        {
            List<Product> allProducts = new List<Product>();

            foreach (var seller in sellers)
            {
                allProducts.AddRange(seller.ListedProducts);
            }

            return allProducts;
        }

        public void DisplayAllProducts(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            foreach (var product in products)
            {
                product.DisplayProductInfo();
            }
        }

        public Product? FindProductById(List<Product> products, int productId)
        {
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Console.WriteLine($"Product found: {product.Name}");
                return product;
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
                return null;
            }
        }

        public void AddProduct(List<Product> products, Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Cannot add a null product.");
                return;
            }
            products.Add(product);
            Console.WriteLine($"Product '{product.Name}' added successfully.");
        }

        public void UpdateProduct(List<Product> products, Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                Console.WriteLine("Cannot update a null product.");
                return;
            }
            var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.StockQuantity = updatedProduct.StockQuantity;
                Console.WriteLine($"Product '{updatedProduct.Name}' updated successfully.");
            }
            else
            {
                Console.WriteLine($"Product with ID {updatedProduct.Id} not found.");
            }
        }
            
        public void DeleteProduct(List<Product> products, int productId)
        {
            var productToRemove = products.FirstOrDefault(p => p.Id == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"Product with ID {productId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }
    }
}