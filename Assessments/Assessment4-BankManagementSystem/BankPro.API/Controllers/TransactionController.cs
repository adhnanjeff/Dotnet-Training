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
        public IActionResult PerformTransaction([FromBody] TransactionRequestDTO transactionRequest)
        {
            try
            {
                _transactionService.PerformTransaction(transactionRequest);
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
        public IActionResult GetTransactionById(Guid id)
        {
            try
            {
                var transaction = _transactionService.GetTransactionById(id);
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
        public IActionResult GetAllTransactions()
        {
            try
            {
                var transactions = _transactionService.GetAllTransactions();
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
