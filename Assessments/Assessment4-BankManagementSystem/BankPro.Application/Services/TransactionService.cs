using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IAccountRepository _accountRepo;

        public TransactionService(ITransactionRepository transactionRepo, IAccountRepository accountRepo)
        {
            _transactionRepo = transactionRepo;
            _accountRepo = accountRepo;
        }

        public async Task PerformTransactionAsync(TransactionRequestDTO transactionRequestDTO)
        {
            if (transactionRequestDTO == null)
            {
                throw new ArgumentNullException(nameof(transactionRequestDTO));
            }

            var fromAccount = await _accountRepo.GetByIdAsync(transactionRequestDTO.FromAccId);
            var toAccount = await _accountRepo.GetByIdAsync(transactionRequestDTO.ToAccId);

            if (fromAccount == null || toAccount == null)
            {
                throw new InvalidOperationException("One or both accounts do not exist.");
            }

            if (fromAccount.BankBalance < transactionRequestDTO.Amount)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            fromAccount.BankBalance -= transactionRequestDTO.Amount;
            toAccount.BankBalance += transactionRequestDTO.Amount;

            await _accountRepo.UpdateAsync(fromAccount);
            await _accountRepo.UpdateAsync(toAccount);

            var transaction = new Transaction
            {
                FromAccId = transactionRequestDTO.FromAccId,
                ToAccId = transactionRequestDTO.ToAccId,
                Amount = transactionRequestDTO.Amount,
                Status = "Success"
            };

            await _transactionRepo.CreateAsync(transaction);
        }

        public async Task<TransactionResponseDTO?> GetTransactionByIdAsync(Guid id)
        {
            var transaction = await _transactionRepo.GetByIdAsync(id);
            if (transaction == null) return null;

            return new TransactionResponseDTO
            {
                TransactionId = transaction.TransactionId,
                FromAccId = transaction.FromAccId,
                ToAccId = transaction.ToAccId,
                Amount = transaction.Amount,
                Status = transaction.Status
            };
        }

        public async Task<List<TransactionResponseDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepo.GetAllAsync();

            return transactions
                .Select(t => new TransactionResponseDTO
                {
                    TransactionId = t.TransactionId,
                    FromAccId = t.FromAccId,
                    ToAccId = t.ToAccId,
                    Amount = t.Amount,
                    Status = t.Status
                })
                .ToList();
        }
    }
}
