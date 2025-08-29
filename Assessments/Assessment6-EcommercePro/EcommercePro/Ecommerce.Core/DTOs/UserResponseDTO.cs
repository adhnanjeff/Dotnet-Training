

namespace Ecommerce.Core.DTOs
{ 
        namespace Ecommerce.Core.DTOs
    {
        public class UserResponseDTO
        {
            public int Id { get; set; }
            public string Username { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Role { get; set; } = "Buyer";

            // For Buyers → Orders they placed
            public List<OrderSummaryDTO>? Orders { get; set; }

            // For Buyers → Products they bought
            public List<ProductSummaryDTO>? BoughtProducts { get; set; }

            // For Sellers → Products they listed
            public List<ProductSummaryDTO>? SoldProducts { get; set; }
        }
    }

}

