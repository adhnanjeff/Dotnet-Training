

using Ecommerce.Core.Entities;

namespace Ecommerce.Core.DTOs
{
    public class ProductRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } = string.Empty;
        public int SellerId { get; set; }  // FK to User
    }
}
