using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult<Product?>(product);
        }

        public Task AddAsync(Product entity)
        {
            // Simple auto-increment logic for in-memory demo
            entity.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(entity);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product entity)
        {
            var index = _products.FindIndex(p => p.Id == entity.Id);
            if (index != -1)
            {
                _products[index] = entity; // replace with updated entity
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }

            return Task.CompletedTask;
        }
    }
}

