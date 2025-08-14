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

        public void CreateCustomer(CustomerRequestDTO customer)
        {
            int nextId = _customerRepo.GetAll().Any()
                ? _customerRepo.GetAll().Max(r => r.Id) + 1
                : 1;

            var newCustomer = new Customer { 
                Id = nextId,
                Name = customer.Name,
                Accounts = new List<Account>()
            };

            _customerRepo.Create(newCustomer);
        }
        public void UpdateCustomer(int id, CustomerRequestDTO customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            var existingCustomer = _customerRepo.GetById(id);
            if (existingCustomer == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            existingCustomer.Name = customer.Name;
            _customerRepo.Update(existingCustomer);
        }


        public void DeleteCustomer(int customerId)
        {
            var customer = _customerRepo.GetById(customerId);
            if (customer != null)
            {
                customer.Accounts?.Clear();
                _customerRepo.Delete(customerId);
            } else
            {
                throw new Exception("No customer with Id provided");
            }
        }

        public CustomerResponseDTO GetCustomerById(int id)
        {
            var customer = _customerRepo.GetById(id);
            if (customer == null)
            {
                throw new Exception("No customer with Id provided");
            }
            return new CustomerResponseDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                Accounts = customer.Accounts
            };
        }
        public List<CustomerResponseDTO> GetAllCustomers()
        {
            List<Customer> transactions = _customerRepo.GetAll();
            if (transactions == null)
            {
                throw new Exception("No customers to display");
            }
            return transactions
                .Select(t => new CustomerResponseDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    Accounts = t.Accounts
                })
                .ToList();
        }
    }
}
