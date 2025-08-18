using BankPro.Core.DTOs;
using BankPro.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // POST: api/Transaction
        [HttpPost]
        public async Task<IActionResult> PerformTransaction([FromBody] TransactionRequestDTO transactionRequest)
        {
            try
            {
                await _transactionService.PerformTransactionAsync(transactionRequest);
                return Ok(new { Message = "Transaction completed successfully" });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            try
            {
                var transaction = await _transactionService.GetTransactionByIdAsync(id);
                if (transaction == null)
                    return NotFound("Transaction not found");

                return Ok(transaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            try
            {
                var transactions = await _transactionService.GetAllTransactionsAsync();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
