using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(AccountRequestDTO account);
        void UpdateAccount(int id, AccountRequestDTO account);
        void DeleteAccount(int id);
        AccountResponseDTO GetAccountById(int id);
        List<AccountResponseDTO> GetAllAccount();
    }
}
