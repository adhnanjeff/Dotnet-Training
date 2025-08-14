using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions = new();
        public void Create(Transaction transaction) => _transactions.Add(transaction);
        public Transaction? GetById(Guid id) => _transactions.FirstOrDefault(t => t.TransactionId == id);
        public List<Transaction> GetAll() => _transactions;
    }
}
