
public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }   // FK to Order
    public int CustomerId { get; set; } // For cart association
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;

    public Order Order { get; set; }   // Navigation property
    public Product Product { get; set; }
}
