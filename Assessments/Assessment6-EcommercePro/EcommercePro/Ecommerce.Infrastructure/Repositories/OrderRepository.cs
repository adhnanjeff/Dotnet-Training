using Ecommerce.Core.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Order>>(_orders);
        }

        public Task<Order?> GetByIdAsync(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return Task.FromResult<Order?>(order);
        }

        public Task AddAsync(Order entity)
        {
            // Simple auto-increment logic for in-memory demo
            entity.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;
            _orders.Add(entity);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Order entity)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == entity.Id);
            if (existingOrder != null)
            {
                existingOrder.TotalAmount = entity.TotalAmount;
                existingOrder.CustomerId = entity.CustomerId;
                existingOrder.Items = entity.Items; 
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
            }

            return Task.CompletedTask;
        }
    }
}

