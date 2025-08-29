

namespace Ecommerce.Core.DTOs
{
    public class OrderItemRequestDTO
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }        
    }
}
