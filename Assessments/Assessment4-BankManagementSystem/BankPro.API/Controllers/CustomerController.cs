using BankPro.Application.Services;
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
        public ActionResult<List<CustomerResponseDTO>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<CustomerResponseDTO> GetCustomerById(int id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Customer
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerRequestDTO customerDto)
        {
            if (customerDto == null)
                return BadRequest("Customer data is required.");

            _customerService.CreateCustomer(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.Name }, customerDto);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerRequestDTO customerDto)
        {
            if (customerDto == null)
                return BadRequest("Customer data is required.");

            try
            {
                _customerService.UpdateCustomer(id, customerDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customerService.DeleteCustomer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
