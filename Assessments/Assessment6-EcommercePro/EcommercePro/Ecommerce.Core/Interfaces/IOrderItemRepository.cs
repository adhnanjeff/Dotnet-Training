

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.Interfaces
{
    public interface IOrderItemRepository
    {
        Task AddAsync(OrderItem orderItem);
        Task DeleteAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem?> GetByIdAsync(int id);
        Task<IEnumerable<OrderItem>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
