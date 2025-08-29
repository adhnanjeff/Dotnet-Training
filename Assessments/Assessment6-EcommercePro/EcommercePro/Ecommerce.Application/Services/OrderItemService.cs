using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OrderItemResponseDTO> AddOrderItemAsync(OrderItemRequestDTO dto)
        {
            var validationErrors = new Dictionary<string, string>();
            if (dto.CustomerId <= 0) validationErrors[nameof(dto.CustomerId)] = "CustomerId is required.";
            if (dto.ProductId <= 0) validationErrors[nameof(dto.ProductId)] = "ProductId is required.";
            if (dto.Quantity <= 0) validationErrors[nameof(dto.Quantity)] = "Quantity must be greater than zero.";
            if (validationErrors.Count > 0)
                throw new ValidationException(validationErrors);

            var customer = await _userRepository.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new NotFoundException($"User with Id {dto.CustomerId} not found.");
            if (!string.Equals(customer.Role, "Buyer", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(customer.Role, "Customer", StringComparison.OrdinalIgnoreCase))
                throw new ForbiddenException("Only customers can add items to cart.");

            var product = await _productRepository.GetByIdAsync(dto.ProductId);
            if (product == null) throw new NotFoundException($"Product with Id {dto.ProductId} not found.");
            if (product.Stock < dto.Quantity) throw new ValidationException(new Dictionary<string, string> { { nameof(dto.Quantity), "Insufficient stock." } });

            var entity = new OrderItem
            {
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = product.Price
            };

            await _orderItemRepository.AddAsync(entity);
            return _mapper.Map<OrderItemResponseDTO>(entity);
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderItemsAsync()
        {
            var entities = await _orderItemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderItemResponseDTO>>(entities);
        }
    }
}
