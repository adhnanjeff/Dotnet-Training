using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new();
        public void Create(Account account) => _accounts.Add(account);
        public Account? GetById(int id) => _accounts.FirstOrDefault(a => a.Id == id);
        public List<Account> GetAll() => _accounts;
        public void Delete(int id)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == id);
            if (existing != null)
            {
                _accounts.Remove(existing);
            }
        }
        public void Update(Account account)
        {
            var existing = _accounts.FirstOrDefault(a => a.Id == account.Id);
            if (existing != null)
            {
                existing.BankBalance = account.BankBalance;
            }
        }
    }
}
