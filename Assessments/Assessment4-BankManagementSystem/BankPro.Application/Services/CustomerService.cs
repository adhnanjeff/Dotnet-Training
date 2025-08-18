using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepo = customerRepository;
        }

        public async Task CreateCustomerAsync(CustomerRequestDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customers = await _customerRepo.GetAllAsync();
            int nextId = customers.Any()
                ? customers.Max(r => r.Id) + 1
                : 1;

            var newCustomer = new Customer
            {
                Id = nextId,
                Name = customer.Name,
                Accounts = new List<Account>()
            };

            await _customerRepo.CreateAsync(newCustomer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerRequestDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existingCustomer = await _customerRepo.GetByIdAsync(id);
            if (existingCustomer == null)
                throw new InvalidOperationException("Customer not found.");

            existingCustomer.Name = customer.Name;
            await _customerRepo.UpdateAsync(existingCustomer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _customerRepo.GetByIdAsync(customerId);
            if (customer != null)
            {
                customer.Accounts?.Clear();
                await _customerRepo.DeleteAsync(customerId);
            }
            else
            {
                throw new Exception("No customer with Id provided");
            }
        }

        public async Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepo.GetByIdAsync(id);
            if (customer == null)
                return null;

            return new CustomerResponseDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Accounts = customer.Accounts
            };
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            if (customers == null || !customers.Any())
                throw new Exception("No customers to display");

            return customers.Select(c => new CustomerResponseDTO
            {
                Id = c.Id,
                Name = c.Name,
                Accounts = c.Accounts
            }).ToList();
        }
    }
}
