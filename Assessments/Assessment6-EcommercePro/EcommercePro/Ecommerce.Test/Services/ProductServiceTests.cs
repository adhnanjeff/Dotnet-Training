using AutoMapper;
using Ecommerce.Application.Mapping;
using Ecommerce.Application.Services;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces;
using Moq;
using Xunit;

namespace Ecommerce.Test.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IMapper _mapper;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mapperConfig.CreateMapper();

            _productService = new ProductService(
                _productRepositoryMock.Object,
                _userRepositoryMock.Object,
                _mapper
            );
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "P1", Price = 10, Stock = 5, SellerId = 100 },
                new Product { Id = 2, Name = "P2", Price = 20, Stock = 2, SellerId = 101 }
            };
            _productRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task AddProductAsync_ShouldValidateSellerRole()
        {
            // Arrange
            var request = new ProductRequestDTO { Name = "P1", Price = 10, Stock = 5, SellerId = 1 };
            var seller = new User { Id = 1, Role = "Seller" };
            _userRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(seller);
            _productRepositoryMock.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

            // Act
            var response = await _productService.AddProductAsync(request);

            // Assert
            Assert.Equal("P1", response.Name);
        }
    }
}
