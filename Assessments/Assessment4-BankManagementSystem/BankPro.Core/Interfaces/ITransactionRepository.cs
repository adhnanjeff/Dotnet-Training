using BankPro.Core.Entities; 

namespace BankPro.Core.Interfaces
{
    public interface ITransactionRepository
    {
        void Create(Transaction transaction);
        List<Transaction> GetAll();
        Transaction? GetById(Guid id);
    }
}
