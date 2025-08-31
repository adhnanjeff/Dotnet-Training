using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Core.Entities;
public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Pending";
    
    // Navigation properties
    public virtual User Customer { get; set; } = null!;
    public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}
