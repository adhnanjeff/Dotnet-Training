

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs
{
    public class OrderRequestDTO
    {
        public int CustomerId { get; set; } 
        public List<int> OrderItemIds { get; set; } = new List<int>();
    }
}
