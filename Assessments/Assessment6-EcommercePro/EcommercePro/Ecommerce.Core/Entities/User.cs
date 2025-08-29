namespace Ecommerce.Core.Entities;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Role { get; set; } = "Buyer";

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Product> Bought { get; set; } = new List<Product>();
    public List<Product> Sold { get; set; } = new List<Product>();
}
