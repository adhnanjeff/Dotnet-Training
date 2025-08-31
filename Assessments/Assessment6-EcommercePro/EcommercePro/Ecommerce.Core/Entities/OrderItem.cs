using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities;
public class OrderItem
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Order")]
    public int? OrderId { get; set; }   // Nullable for cart items
    
    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; } // For cart association
    
    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }
    
    [NotMapped]
    public decimal TotalPrice => Quantity * UnitPrice;

    // Navigation properties
    public virtual Order? Order { get; set; }
    public virtual User Customer { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}
