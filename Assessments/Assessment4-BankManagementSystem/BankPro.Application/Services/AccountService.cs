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

        public async Task CreateAccountAsync(AccountRequestDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var allAccounts = await _accountRepo.GetAllAsync();
            int nextId = allAccounts.Any()
                ? allAccounts.Max(r => r.Id) + 1
                : 1;

            var newAccount = new Account
            {
                Id = nextId,
                AccHolderId = account.AccHolderId,
                BankBalance = account.BankBalance,
                Transactions = new List<Transaction>()
            };

            var user = await _customerRepo.GetByIdAsync(account.AccHolderId);
            if (user == null)
            {
                throw new Exception($"Customer with Id {account.AccHolderId} not found.");
            }

            user.Accounts.Add(newAccount);

            await _accountRepo.CreateAsync(newAccount);
        }

        public async Task UpdateAccountAsync(int id, AccountRequestDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var existingAccount = await _accountRepo.GetByIdAsync(id);
            if (existingAccount == null)
            {
                throw new Exception("No account with the provided Id.");
            }

            existingAccount.BankBalance = account.BankBalance;
            existingAccount.AccHolderId = account.AccHolderId;

            await _accountRepo.UpdateAsync(existingAccount);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var deleteAccount = await _accountRepo.GetByIdAsync(id);
            if (deleteAccount != null)
            {
                await _accountRepo.DeleteAsync(id);
            }
            else
            {
                throw new Exception("No account with the provided Id.");
            }
        }

        public async Task<AccountResponseDTO> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
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

        public async Task<List<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();

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
