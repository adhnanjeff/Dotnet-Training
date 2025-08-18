using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface ITransactionService
    {
        Task PerformTransactionAsync(TransactionRequestDTO transaction);
        Task<TransactionResponseDTO?> GetTransactionByIdAsync(Guid transactionId);
        Task<List<TransactionResponseDTO>> GetAllTransactionsAsync();
    }
}
