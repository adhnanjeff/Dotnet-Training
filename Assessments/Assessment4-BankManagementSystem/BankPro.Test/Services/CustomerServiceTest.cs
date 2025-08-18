using AutoMapper;
using BankPro.Application.Services;
using BankPro.Core.DTOs;
using BankPro.Core.Entities;
using BankPro.Core.Interfaces;
using Moq;

namespace BankPro.Test.Services
{
    public class CustomerServiceTest
    {
        private readonly Mock<ICustomerRepository> _customerRepoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CustomerService _service;

        public CustomerServiceTest()
        {
            _customerRepoMock = new Mock<ICustomerRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new CustomerService(_customerRepoMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task CreateCustomer_Should_Create_New_Customer()
        {
            // Arrange
            var dto = new CustomerRequestDTO { Name = "Jeff" };
            _customerRepoMock.Setup(r => r.GetAllAsync())
                             .ReturnsAsync(new List<Customer>());

            // Act
            await _service.CreateCustomerAsync(dto);

            // Assert
            _customerRepoMock.Verify(r => r.CreateAsync(It.Is<Customer>(c =>
                c.Name == "Jeff" &&
                c.Id == 1 &&
                c.Accounts.Count == 0
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateCustomer_Should_Update_Existing_Customer()
        {
            // Arrange
            var existingCustomer = new Customer { Id = 1, Name = "Old Name" };
            var updatedDto = new CustomerRequestDTO { Name = "New Name" };

            _customerRepoMock.Setup(r => r.GetByIdAsync(1))
                             .ReturnsAsync(existingCustomer);

            // Act
            await _service.UpdateCustomerAsync(1, updatedDto);

            // Assert
            _customerRepoMock.Verify(r => r.UpdateAsync(It.Is<Customer>(c =>
                c.Id == 1 &&
                c.Name == "New Name"
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateCustomer_Should_Throw_When_Customer_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetByIdAsync(99))
                             .ReturnsAsync((Customer)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _service.UpdateCustomerAsync(99, new CustomerRequestDTO { Name = "X" }));
        }

        [Fact]
        public async Task DeleteCustomer_Should_Delete_When_Found()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Jeff",
                Accounts = new List<Account> { new Account { Id = 10 } }
            };
            _customerRepoMock.Setup(r => r.GetByIdAsync(1))
                             .ReturnsAsync(customer);

            // Act
            await _service.DeleteCustomerAsync(1);

            // Assert
            _customerRepoMock.Verify(r => r.DeleteAsync(1), Times.Once);
            Assert.Empty(customer.Accounts);
        }

        [Fact]
        public async Task DeleteCustomer_Should_Throw_When_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetByIdAsync(1))
                             .ReturnsAsync((Customer)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
                await _service.DeleteCustomerAsync(1));
        }

        [Fact]
        public async Task GetCustomerById_Should_Return_CustomerResponseDTO()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Adhnan",
                Accounts = new List<Account>()
            };
            _customerRepoMock.Setup(r => r.GetByIdAsync(1))
                             .ReturnsAsync(customer);

            // Act
            var result = await _service.GetCustomerByIdAsync(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("Adhnan", result.Name);
        }

        [Fact]
        public async Task GetCustomerById_Should_Throw_When_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetByIdAsync(1))
                             .ReturnsAsync((Customer)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
                await _service.GetCustomerByIdAsync(1));
        }

        [Fact]
        public async Task GetAllCustomers_Should_Return_List()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "A", Accounts = new List<Account>() },
                new Customer { Id = 2, Name = "B", Accounts = new List<Account>() }
            };
            _customerRepoMock.Setup(r => r.GetAllAsync())
                             .ReturnsAsync(customers);

            // Act
            var result = await _service.GetAllCustomersAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("A", result[0].Name);
        }

        [Fact]
        public async Task GetAllCustomers_Should_Throw_When_Null()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetAllAsync())
                             .ReturnsAsync((List<Customer>)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () =>
                await _service.GetAllCustomersAsync());
        }
    }
}
