

namespace BankPro.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int AccHolderId { get; set; }
        public Customer AccHolder { get; set; } = null!;
        public float BankBalance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
