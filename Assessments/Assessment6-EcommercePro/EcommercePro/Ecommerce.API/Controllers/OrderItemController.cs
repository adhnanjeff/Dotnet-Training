using Ecommerce.Core.DTOs;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 Require JWT authentication for all endpoints
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")] // 🔐 Only Admin can view all order items
        public async Task<IActionResult> GetAll()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return Ok(orderItems);
        }

        [HttpPost]
        [Authorize(Roles = "Buyer")] // 🔐 Only Buyers can create order items (add to cart)
        public async Task<IActionResult> Create(OrderItemRequestDTO dto)
        {
            var orderItem = await _orderItemService.AddOrderItemAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id = orderItem.Id }, orderItem);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Buyer,Admin")] // 🔐 Buyers can remove items from cart, Admin can delete any
        public async Task<IActionResult> Delete(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return NoContent();
        }
    }
}
