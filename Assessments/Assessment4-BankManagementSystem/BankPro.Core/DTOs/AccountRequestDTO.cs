

using BankPro.Core.Entities;

namespace BankPro.Core.DTOs
{
    public class AccountRequestDTO
    {
        public int AccHolderId { get; set; }
        public float BankBalance { get; set; }
    }
}
