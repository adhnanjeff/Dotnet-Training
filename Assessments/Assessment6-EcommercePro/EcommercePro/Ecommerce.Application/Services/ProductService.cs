using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponseDTO> AddProductAsync(ProductRequestDTO product)
        {
            var validationErrors = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(product.Name)) validationErrors[nameof(product.Name)] = "Name is required.";
            if (product.Price <= 0) validationErrors[nameof(product.Price)] = "Price must be greater than zero.";
            if (product.Stock < 0) validationErrors[nameof(product.Stock)] = "Stock cannot be negative.";
            if (product.SellerId <= 0) validationErrors[nameof(product.SellerId)] = "SellerId must be a positive integer.";

            if (validationErrors.Count > 0)
                throw new ValidationException(validationErrors);

            var seller = await _userRepository.GetByIdAsync(product.SellerId);
            if (seller == null)
                throw new NotFoundException($"User with Id {product.SellerId} not found.");

            if (!string.Equals(seller.Role, "Seller", StringComparison.OrdinalIgnoreCase))
                throw new ForbiddenException("Only users with role 'Seller' can create products.");

            var entity = _mapper.Map<Product>(product);
            entity.SellerId = seller.Id;

            await _productRepository.AddAsync(entity);
            return _mapper.Map<ProductResponseDTO>(entity);
        }

        public async Task UpdateProductAsync(int id, ProductRequestDTO product)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            // Map updated fields into a new entity
            var updatedEntity = _mapper.Map<Product>(product);
            updatedEntity.Id = id; // preserve original Id

            await _productRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteProductAsync(int id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Product with Id {id} not found.");

            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<ProductResponseDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<List<ProductResponseDTO>>(products);
        }

        public async Task<ProductResponseDTO?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductResponseDTO>(product);
        }
    }
}
