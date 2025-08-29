using Moq;
using AutoMapper;
using Ecommerce.Core.Interfaces;
using Ecommerce.Application.Services;
using Ecommerce.Core.DTOs;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repoMock;
    private readonly IMapper _mapper;
    private readonly ProductService _service;

    public ProductServiceTests()
    {
        _repoMock = new Mock<IProductRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductRequestDTO, Product>();
            cfg.CreateMap<Product, ProductResponseDTO>();
        });
        _mapper = config.CreateMapper();

        _service = new ProductService(_repoMock.Object, _mapper);
    }

    [Fact]
    public async Task AddProductAsync_ShouldReturnResponseDTO()
    {
        // Arrange
        var request = new ProductRequestDTO { Name = "Laptop", Price = 1200 };
        var entity = new Product { Id = 1, Name = "Laptop", Price = 1200 };

        _repoMock.Setup(r => r.AddAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);

        // Act
        var result = await _service.AddProductAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Laptop", result.Name);
    }
}
