

namespace BankPro.Core.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; set; } = Guid.NewGuid();
        public int FromAccId { get; set; }
        public int ToAccId { get; set; }
        public float Amount { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
