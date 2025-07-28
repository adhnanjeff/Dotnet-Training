using System.Collections.Generic;
using Assessment1_Ecommerce.Models;

namespace Assessment1_Ecommerce.Services
{
    public interface IProductService
    {
        void AddProduct(List<Product> products, Product product);
        void UpdateProduct(List<Product> products, Product product);
        void DeleteProduct(List<Product> products, int productId);
        void DisplayAllProducts(List<Product> products);
        Product? FindProductById(List<Product> products, int productId);
    }
}