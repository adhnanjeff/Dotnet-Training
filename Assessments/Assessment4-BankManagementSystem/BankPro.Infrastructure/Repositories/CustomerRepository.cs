using BankPro.Core.Entities;
using BankPro.Core.Interfaces;

namespace BankPro.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();
        public void Create(Customer customer) => _customers.Add(customer);
        public Customer? GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);
        public List<Customer> GetAll() => _customers;
        public void Delete(int id)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == id);
            if (existing != null)
            {
                _customers.Remove(existing);
            }
        }
        public void Update(Customer customer)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing != null)
            {
                existing.Name = customer.Name;
            }
        }
    }
}
