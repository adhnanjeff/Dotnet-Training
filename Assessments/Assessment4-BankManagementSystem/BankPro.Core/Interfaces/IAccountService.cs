using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccountAsync(AccountRequestDTO account);
        Task UpdateAccountAsync(int id, AccountRequestDTO account);
        Task DeleteAccountAsync(int id);
        Task<AccountResponseDTO?> GetAccountByIdAsync(int id);
        Task<List<AccountResponseDTO>> GetAllAccountsAsync();
    }
}
