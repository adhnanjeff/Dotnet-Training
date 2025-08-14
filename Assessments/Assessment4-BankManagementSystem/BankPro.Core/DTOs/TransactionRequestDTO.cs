

namespace BankPro.Core.DTOs
{
    public class TransactionRequestDTO
    {
        public int FromAccId { get; set; }
        public int ToAccId { get; set; }
        public float Amount { get; set; }
    }
}
