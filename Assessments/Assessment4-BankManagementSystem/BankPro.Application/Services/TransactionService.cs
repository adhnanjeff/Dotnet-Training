using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IAccountRepository _accountRepo;
        public TransactionService(ITransactionRepository transactionRepo, IAccountRepository accountRepo) { 
            _transactionRepo = transactionRepo;
            _accountRepo = accountRepo;
        }
        public void PerformTransaction(TransactionRequestDTO transactionRequestDTO)
        {
            if (transactionRequestDTO == null)
            {
                throw new ArgumentNullException(nameof(transactionRequestDTO));
            }

            var fromAccount = _accountRepo.GetById(transactionRequestDTO.FromAccId);
            var toAccount = _accountRepo.GetById(transactionRequestDTO.ToAccId);

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

            _accountRepo.Update(fromAccount);
            _accountRepo.Update(toAccount);

            var transaction = new Transaction
            {
                FromAccId = transactionRequestDTO.FromAccId,
                ToAccId = transactionRequestDTO.ToAccId,
                Amount = transactionRequestDTO.Amount,
                Status = "Success"
            };
            _transactionRepo.Create(transaction);
        }

        public TransactionResponseDTO GetTransactionById(Guid id)
        {
            var transaction = _transactionRepo.GetById(id);
            return new TransactionResponseDTO
            {
                TransactionId = transaction.TransactionId,
                FromAccId = transaction.FromAccId,
                ToAccId = transaction.ToAccId,
                Amount = transaction.Amount,
                Status = transaction.Status
            };
        }

        public List<TransactionResponseDTO> GetAllTransactions()
        {
            List<Transaction> transactions = _transactionRepo.GetAll();

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
