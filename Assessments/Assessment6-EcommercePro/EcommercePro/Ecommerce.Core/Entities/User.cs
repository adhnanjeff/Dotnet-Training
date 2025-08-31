using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities;
public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string Role { get; set; } = "Buyer";

    // Navigation properties
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Product> SoldProducts { get; set; } = new List<Product>();
    public virtual ICollection<OrderItem> CartItems { get; set; } = new List<OrderItem>();
}
