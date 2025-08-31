using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities;
public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required]
    public int Stock { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Category { get; set; } = string.Empty;

    [Required]
    [ForeignKey("Seller")]
    public int SellerId { get; set; }
    
    // Navigation property
    public virtual User Seller { get; set; } = null!;
    
    // Navigation properties
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
