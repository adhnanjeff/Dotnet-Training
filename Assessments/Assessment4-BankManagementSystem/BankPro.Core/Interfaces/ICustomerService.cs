using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(CustomerRequestDTO customer);
        Task UpdateCustomerAsync(int id, CustomerRequestDTO customer);
        Task DeleteCustomerAsync(int id);
        Task<CustomerResponseDTO?> GetCustomerByIdAsync(int id);
        Task<List<CustomerResponseDTO>> GetAllCustomersAsync();
    }
}
