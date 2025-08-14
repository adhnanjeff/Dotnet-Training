

using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface ITransactionService
    {
        void PerformTransaction(TransactionRequestDTO transaction);
        TransactionResponseDTO GetTransactionById(Guid transactionId);
        List<TransactionResponseDTO> GetAllTransactions();
    }
}
