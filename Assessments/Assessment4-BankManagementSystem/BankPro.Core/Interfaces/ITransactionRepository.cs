using BankPro.Core.Entities;

namespace BankPro.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Task CreateAsync(Transaction transaction);              
        Task<List<Transaction>> GetAllAsync();                  
        Task<Transaction?> GetByIdAsync(Guid id);               
    }
}
