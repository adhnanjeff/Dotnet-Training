using BankPro.Core.DTOs;
using BankPro.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<List<CustomerResponseDTO>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomersAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound(new { message = "Customer not found" });

            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRequestDTO customerDto)
        {
            if (customerDto == null)
                return BadRequest("Customer data is required.");

            await _customerService.CreateCustomerAsync(customerDto);
            return Ok(new { message = "Customer created successfully" });
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerRequestDTO customerDto)
        {
            if (customerDto == null)
                return BadRequest("Customer data is required.");

            try
            {
                await _customerService.UpdateCustomerAsync(id, customerDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
