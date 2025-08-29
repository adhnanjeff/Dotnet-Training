using Ecommerce.Core.DTOs;

namespace Ecommerce.Core.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemResponseDTO> AddOrderItemAsync(OrderItemRequestDTO dto);
        Task DeleteOrderItemAsync(int orderId);
        Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderItemsAsync();
    }
}
