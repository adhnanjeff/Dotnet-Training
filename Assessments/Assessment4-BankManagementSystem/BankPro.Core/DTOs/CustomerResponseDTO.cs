using BankPro.Core.Entities;

namespace BankPro.Core.DTOs
{
    public class CustomerResponseDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
