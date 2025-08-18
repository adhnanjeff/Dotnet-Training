using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();

        public Task CreateAsync(Transaction transaction)
        {
            _transactions.Add(transaction);
            return Task.CompletedTask;
        }

        public Task<Transaction?> GetByIdAsync(Guid id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.TransactionId == id);
            return Task.FromResult(transaction);
        }

        public Task<List<Transaction>> GetAllAsync() => Task.FromResult(_transactions.ToList());
        
    }
}
