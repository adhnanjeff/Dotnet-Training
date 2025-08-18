using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public Task CreateAsync(Customer customer)
        {
            _customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return Task.FromResult(_customers.ToList());
        }

        public Task DeleteAsync(int id)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                _customers.Remove(existing);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing != null)
            {
                existing.Name = customer.Name;
            }
            return Task.CompletedTask;
        }
    }
}
