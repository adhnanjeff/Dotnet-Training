using Ecommerce.Core.Interfaces;

namespace Ecommerce.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly List<OrderItem> _orderItems = new();
        public Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<OrderItem>>(_orderItems);
        }
        public Task AddAsync(OrderItem orderItem)
        {
            orderItem.Id = _orderItems.Count > 0 ? _orderItems.Max(oi => oi.Id) + 1 : 1;
            _orderItems.Add(orderItem);

            return Task.CompletedTask;
        }
        public Task DeleteAsync(int orderItemId)
        {
            _orderItems.RemoveAll(oi => oi.Id == orderItemId);
            return Task.CompletedTask;
        }

        public Task<OrderItem?> GetByIdAsync(int id)
        {
            var item = _orderItems.FirstOrDefault(oi => oi.Id == id);
            return Task.FromResult<OrderItem?>(item);
        }

        public Task<IEnumerable<OrderItem>> GetByIdsAsync(IEnumerable<int> ids)
        {
            var set = new HashSet<int>(ids);
            var items = _orderItems.Where(oi => set.Contains(oi.Id));
            return Task.FromResult<IEnumerable<OrderItem>>(items);
        }
    }
}
