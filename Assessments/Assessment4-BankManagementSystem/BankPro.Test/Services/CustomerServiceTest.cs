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
        private readonly CustomerService _service;

        public CustomerServiceTest()
        {
            _customerRepoMock = new Mock<ICustomerRepository>();
            _service = new CustomerService(_customerRepoMock.Object);
        }

        [Fact]
        public void CreateCustomer_Should_Create_New_Customer()
        {
            // Arrange
            var dto = new CustomerRequestDTO { Name = "Jeff" };
            _customerRepoMock.Setup(r => r.GetAll())
                             .Returns(new List<Customer>());

            // Act
            _service.CreateCustomer(dto);

            // Assert
            _customerRepoMock.Verify(r => r.Create(It.Is<Customer>(c =>
                c.Name == "Jeff" &&
                c.Id == 1 &&
                c.Accounts.Count == 0
            )), Times.Once);
        }

        [Fact]
        public void UpdateCustomer_Should_Update_Existing_Customer()
        {
            // Arrange
            var existingCustomer = new Customer { Id = 1, Name = "Old Name" };
            var updatedDto = new CustomerRequestDTO { Name = "New Name" };

            _customerRepoMock.Setup(r => r.GetById(1))
                             .Returns(existingCustomer);

            // Act
            _service.UpdateCustomer(1, updatedDto);

            // Assert
            _customerRepoMock.Verify(r => r.Update(It.Is<Customer>(c =>
                c.Id == 1 &&
                c.Name == "New Name"
            )), Times.Once);
        }

        [Fact]
        public void UpdateCustomer_Should_Throw_When_Customer_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetById(99))
                             .Returns((Customer)null);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() =>
                _service.UpdateCustomer(99, new CustomerRequestDTO { Name = "X" }));
        }

        [Fact]
        public void DeleteCustomer_Should_Delete_When_Found()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Jeff",
                Accounts = new List<Account> { new Account { Id = 10 } }
            };
            _customerRepoMock.Setup(r => r.GetById(1))
                             .Returns(customer);

            // Act
            _service.DeleteCustomer(1);

            // Assert
            _customerRepoMock.Verify(r => r.Delete(1), Times.Once);
            Assert.Empty(customer.Accounts);
        }

        [Fact]
        public void DeleteCustomer_Should_Throw_When_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetById(1))
                             .Returns((Customer)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _service.DeleteCustomer(1));
        }

        [Fact]
        public void GetCustomerById_Should_Return_CustomerResponseDTO()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Name = "Jane",
                Accounts = new List<Account>()
            };
            _customerRepoMock.Setup(r => r.GetById(1))
                             .Returns(customer);

            // Act
            var result = _service.GetCustomerById(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("Jane", result.Name);
        }

        [Fact]
        public void GetCustomerById_Should_Throw_When_Not_Found()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetById(1))
                             .Returns((Customer)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _service.GetCustomerById(1));
        }

        [Fact]
        public void GetAllCustomers_Should_Return_List()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "A", Accounts = new List<Account>() },
                new Customer { Id = 2, Name = "B", Accounts = new List<Account>() }
            };
            _customerRepoMock.Setup(r => r.GetAll())
                             .Returns(customers);

            // Act
            var result = _service.GetAllCustomers();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("A", result[0].Name);
        }

        [Fact]
        public void GetAllCustomers_Should_Throw_When_Null()
        {
            // Arrange
            _customerRepoMock.Setup(r => r.GetAll())
                             .Returns((List<Customer>)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _service.GetAllCustomers());
        }
    }
}
