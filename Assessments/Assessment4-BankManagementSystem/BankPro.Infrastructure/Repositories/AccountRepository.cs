using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new();

        public Task CreateAsync(Account account)
        {
            _accounts.Add(account);
            return Task.CompletedTask; 
        }

        public Task<Account?> GetByIdAsync(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(account);
        }

        public Task<List<Account>> GetAllAsync()
        {
            return Task.FromResult(_accounts.ToList());
        }

        public Task DeleteAsync(int id)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == id);
            if (existing != null)
            {
                _accounts.Remove(existing);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Account account)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existing != null)
            {
                existing.BankBalance = account.BankBalance;
            }
            return Task.CompletedTask;
        }
    }
}
