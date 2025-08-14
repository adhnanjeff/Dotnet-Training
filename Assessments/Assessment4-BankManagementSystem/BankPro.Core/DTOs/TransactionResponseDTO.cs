

namespace BankPro.Core.DTOs
{
    public class TransactionResponseDTO
    {
        public Guid TransactionId { get; set; }
        public int FromAccId { get; set; }
        public int ToAccId { get; set; }
        public float Amount { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
