using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ICustomerRepository _customerRepo;

        public AccountService(IAccountRepository accountRepo, ICustomerRepository customerRepo)
        {
            _accountRepo = accountRepo;
            _customerRepo = customerRepo;
        }

        public void CreateAccount(AccountRequestDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            int nextId = _accountRepo.GetAll().Any()
                ? _accountRepo.GetAll().Max(r => r.Id) + 1
                : 1;

            var newAccount = new Account
            {
                Id = nextId,
                AccHolderId = account.AccHolderId,
                BankBalance = account.BankBalance,
                Transactions = new List<Transaction>()
            };
            var user = _customerRepo.GetById(account.AccHolderId);
            user.Accounts.Add(newAccount);

            _accountRepo.Create(newAccount);
        }

        public void UpdateAccount(int id, AccountRequestDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var existingAccount = _accountRepo.GetById(id);
            if (existingAccount == null)
            {
                throw new Exception("No account with the provided Id.");
            }

            existingAccount.BankBalance = account.BankBalance;
            existingAccount.AccHolderId = account.AccHolderId;

            _accountRepo.Update(existingAccount);
        }

        public void DeleteAccount(int id)
        {
            var deleteAccount = _accountRepo.GetById(id);
            if (deleteAccount != null)
            {
                _accountRepo.Delete(id);
            }
            else
            {
                throw new Exception("No account with the provided Id.");
            }
        }

        public AccountResponseDTO GetAccountById(int id)
        {
            var account = _accountRepo.GetById(id);
            if (account == null)
            {
                throw new Exception("No account with the provided Id.");
            }

            return new AccountResponseDTO
            {
                Id = account.Id,
                BankBalance = account.BankBalance,
                AccHolder = account.AccHolder?.Name ?? "Unknown",
                Transactions = account.Transactions
            };
        }

        public List<AccountResponseDTO> GetAllAccount()
        {
            var accounts = _accountRepo.GetAll();

            return accounts.Select(t => new AccountResponseDTO
            {
                Id = t.Id,
                BankBalance = t.BankBalance,
                AccHolder = t.AccHolder?.Name ?? "Unknown",
                Transactions = t.Transactions
            }).ToList();
        }
    }
}
