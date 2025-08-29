

using Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> AddOrderAsync(OrderRequestDTO user);
        Task UpdateOrderAsync(int id, OrderRequestDTO user);
        Task DeleteOrderAsync(int id);
        Task<List<OrderResponseDTO>> GetAllOrdersAsync();
        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
    }
}
