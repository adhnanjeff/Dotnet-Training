using BankPro.Core.DTOs;
using BankPro.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Account/{id}
        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var account = _accountService.GetAccountById(id);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Account
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            try
            {
                var accounts = _accountService.GetAllAccount();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Account
        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountRequestDTO account)
        {
            try
            {
                _accountService.CreateAccount(account);
                return Ok(new { message = "Account created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Account/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, [FromBody] AccountRequestDTO account)
        {
            try
            {
                _accountService.UpdateAccount(id, account);
                return Ok(new { message = "Account updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Account/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                _accountService.DeleteAccount(id);
                return Ok(new { message = "Account deleted successfully." });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
