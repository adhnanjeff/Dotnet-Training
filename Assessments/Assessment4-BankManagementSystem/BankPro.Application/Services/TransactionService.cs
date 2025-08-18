using AutoMapper;
using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;
        private readonly IAccountRepository _accountRepo;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepo, IAccountRepository accountRepo, IMapper mapper)
        {
            _transactionRepo = transactionRepo;
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task PerformTransactionAsync(TransactionRequestDTO transactionRequestDTO)
        {
            if (transactionRequestDTO == null)
                throw new ArgumentNullException(nameof(transactionRequestDTO));

            var fromAccount = await _accountRepo.GetByIdAsync(transactionRequestDTO.FromAccId);
            var toAccount = await _accountRepo.GetByIdAsync(transactionRequestDTO.ToAccId);

            if (fromAccount == null || toAccount == null)
                throw new InvalidOperationException("One or both accounts do not exist.");

            if (fromAccount.BankBalance < transactionRequestDTO.Amount)
                throw new InvalidOperationException("Insufficient funds.");

            fromAccount.BankBalance -= transactionRequestDTO.Amount;
            toAccount.BankBalance += transactionRequestDTO.Amount;

            await _accountRepo.UpdateAsync(fromAccount);
            await _accountRepo.UpdateAsync(toAccount);

            var transaction = _mapper.Map<Transaction>(transactionRequestDTO);
            transaction.TransactionId = Guid.NewGuid();
            transaction.Status = "Success";

            await _transactionRepo.CreateAsync(transaction);
        }

        public async Task<TransactionResponseDTO?> GetTransactionByIdAsync(Guid transactionId)
        {
            var transaction = await _transactionRepo.GetByIdAsync(transactionId);
            return transaction == null ? null : _mapper.Map<TransactionResponseDTO>(transaction);
        }

        public async Task<List<TransactionResponseDTO>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepo.GetAllAsync();
            return _mapper.Map<List<TransactionResponseDTO>>(transactions);
        }
    }
}
