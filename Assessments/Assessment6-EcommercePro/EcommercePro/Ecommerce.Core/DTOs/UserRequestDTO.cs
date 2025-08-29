

namespace Ecommerce.Core.DTOs
{
    public class UserRequestDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "Buyer";
    }
}
