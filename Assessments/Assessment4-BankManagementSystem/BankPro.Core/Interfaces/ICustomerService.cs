using BankPro.Core.DTOs;

namespace BankPro.Core.Interfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerRequestDTO customer);
        void UpdateCustomer(int id, CustomerRequestDTO customer);
        void DeleteCustomer(int id);
        CustomerResponseDTO GetCustomerById(int id);
        List<CustomerResponseDTO> GetAllCustomers();
    }
}
