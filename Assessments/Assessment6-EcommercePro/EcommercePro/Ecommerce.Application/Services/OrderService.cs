using AutoMapper;
using Ecommerce.Core.DTOs;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Exceptions;
using Ecommerce.Core.Interfaces;

namespace Ecommerce.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponseDTO> AddOrderAsync(OrderRequestDTO request)
        {
            var errors = new Dictionary<string, string>();
            if (request.CustomerId <= 0) errors[nameof(request.CustomerId)] = "CustomerId is required.";
            if (request.OrderItemIds == null || request.OrderItemIds.Count == 0) errors[nameof(request.OrderItemIds)] = "At least one order item id is required.";
            if (errors.Count > 0) throw new ValidationException(errors);

            var customer = await _userRepository.GetByIdAsync(request.CustomerId);
            if (customer == null) throw new NotFoundException($"User with Id {request.CustomerId} not found.");

            var order = new Order
            {
                CustomerId = request.CustomerId,
                Status = "Completed",
                Items = new List<OrderItem>()
            };

            decimal total = 0;
            foreach (var idOrder in request.OrderItemIds)
            {
                var cartItem = await _orderItemRepository.GetByIdAsync(idOrder);
                if (cartItem == null) throw new NotFoundException($"Order item with Id {idOrder} not found.");
                if (cartItem.CustomerId != request.CustomerId) throw new ForbiddenException("Order item does not belong to this customer.");

                var product = await _productRepository.GetByIdAsync(cartItem.ProductId);
                if (product == null) throw new NotFoundException($"Product with Id {cartItem.ProductId} not found.");
                if (cartItem.Quantity <= 0) throw new ValidationException(new Dictionary<string, string> { { nameof(cartItem.Quantity), "Quantity must be greater than zero." } });
                if (product.Stock < cartItem.Quantity) throw new ValidationException(new Dictionary<string, string> { { nameof(cartItem.Quantity), "Insufficient stock." } });

                cartItem.UnitPrice = product.Price; // ensure current price
                total += cartItem.TotalPrice;
                order.Items.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });

                product.Stock -= cartItem.Quantity; // reduce stock upon order creation
                await _productRepository.UpdateAsync(product);

                // clear cart item
                await _orderItemRepository.DeleteAsync(cartItem.Id);
            }

            order.TotalAmount = total;
            await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderResponseDTO>(order);
        }

        public async Task UpdateOrderAsync(int id, OrderRequestDTO request)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
                throw new NotFoundException("Order not found");

            if (existingOrder.Status == "Completed")
                throw new ForbiddenException("Cannot update completed orders");

            if (request.OrderItemIds == null || request.OrderItemIds.Count == 0)
                throw new ValidationException(new Dictionary<string, string> { { nameof(request.OrderItemIds), "At least one order item id is required." } });

            existingOrder.CustomerId = request.CustomerId;
            existingOrder.Items.Clear();

            decimal total = 0;
            foreach (var idOrder in request.OrderItemIds)
            {
                var cartItem = await _orderItemRepository.GetByIdAsync(idOrder);
                if (cartItem == null) throw new NotFoundException($"Order item with Id {idOrder} not found.");
                if (cartItem.CustomerId != request.CustomerId) throw new ForbiddenException("Order item does not belong to this customer.");

                var product = await _productRepository.GetByIdAsync(cartItem.ProductId);
                if (product == null) throw new NotFoundException($"Product with Id {cartItem.ProductId} not found.");
                if (cartItem.Quantity <= 0) throw new ValidationException(new Dictionary<string, string> { { nameof(cartItem.Quantity), "Quantity must be greater than zero." } });
                if (product.Stock < cartItem.Quantity) throw new ValidationException(new Dictionary<string, string> { { nameof(cartItem.Quantity), "Insufficient stock." } });

                cartItem.UnitPrice = product.Price;
                total += cartItem.TotalPrice;
                existingOrder.Items.Add(new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.UnitPrice
                });
            }

            existingOrder.TotalAmount = total;

            await _orderRepository.UpdateAsync(existingOrder);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(id);
            if (existingOrder == null)
                throw new NotFoundException("Order not found");

            if (existingOrder.Status == "Completed")
                throw new ForbiddenException("Cannot delete completed orders");

            await _orderRepository.DeleteAsync(id);
        }

        public async Task<List<OrderResponseDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderResponseDTO>>(orders);
        }

        public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order != null ? _mapper.Map<OrderResponseDTO>(order) : null;
        }
    }
}
