using AutoMapper;
using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepo, ICustomerRepository customerRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task CreateAccountAsync(AccountRequestDTO account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var user = await _customerRepo.GetByIdAsync(account.AccHolderId);
            if (user == null)
                throw new Exception($"Customer with Id {account.AccHolderId} not found.");

            var newAccount = _mapper.Map<Account>(account);

            user.Accounts ??= new List<Account>();
            user.Accounts.Add(newAccount);

            await _accountRepo.CreateAsync(newAccount);
        }

        public async Task UpdateAccountAsync(int id, AccountRequestDTO account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            var existingAccount = await _accountRepo.GetByIdAsync(id);
            if (existingAccount == null)
                throw new Exception("No account with the provided Id.");

            // map updated fields
            _mapper.Map(account, existingAccount);

            await _accountRepo.UpdateAsync(existingAccount);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var deleteAccount = await _accountRepo.GetByIdAsync(id);
            if (deleteAccount == null)
                throw new Exception("No account with the provided Id.");

            await _accountRepo.DeleteAsync(id);
        }

        public async Task<AccountResponseDTO?> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            if (account == null) return null;

            return new AccountResponseDTO
            {
                Id = account.Id,
                BankBalance = account.BankBalance,
                AccHolder = account.AccHolder?.Name   // ✅ manually set
            };
        }


        public async Task<List<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return _mapper.Map<List<AccountResponseDTO>>(accounts);
        }
    }
}
