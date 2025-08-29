

namespace Ecommerce.Core.DTOs
{
    public class OrderSummaryDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
