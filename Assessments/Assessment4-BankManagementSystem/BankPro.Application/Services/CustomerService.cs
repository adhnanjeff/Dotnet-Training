using AutoMapper;
using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepo = customerRepository;
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CustomerRequestDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var customers = await _customerRepo.GetAllAsync();
            int nextId = customers.Any()
                ? customers.Max(r => r.Id) + 1
                : 1;

            var newCustomer = _mapper.Map<Customer>(customer);
            newCustomer.Id = nextId;
            newCustomer.Accounts = new List<Account>();

            await _customerRepo.CreateAsync(newCustomer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerRequestDTO customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            var existingCustomer = await _customerRepo.GetByIdAsync(id);
            if (existingCustomer == null)
                throw new InvalidOperationException("Customer not found.");

            _mapper.Map(customer, existingCustomer);

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

            return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task<List<CustomerResponseDTO>> GetAllCustomersAsync()
        {
            var customers = await _customerRepo.GetAllAsync();
            if (customers == null || !customers.Any())
                throw new Exception("No customers to display");

            return _mapper.Map<List<CustomerResponseDTO>>(customers);
        }
    }
}
