using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderItemsController(IOrderItemItemService _orderItemItemService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var orderItems = await _orderItemItemService.GetAllOrderItems();
            return CreateResponse(orderItems);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItemById(int id)
        {
            var orderItem = await _orderItemItemService.GetOrderItemById(id);
            return CreateResponse(orderItem);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(CreateOrderItemDto createOrderItemDto)
        {
            var result = await _orderItemItemService.CreateOrderItem(createOrderItemDto);
            return CreateResponse(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto)
        {
            var result = await _orderItemItemService.UpdateOrderItem(updateOrderItemDto);
            return CreateResponse(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            var result = await _orderItemItemService.DeleteOrderItem(id);
            return CreateResponse(result);
        }
    }
}
