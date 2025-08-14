

using BankPro.Core.Entities;

namespace BankPro.Core.DTOs
{
    public class AccountResponseDTO
    {
        public int Id { get; set; }
        public string AccHolder { get; set; } = null!;
        public float BankBalance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
