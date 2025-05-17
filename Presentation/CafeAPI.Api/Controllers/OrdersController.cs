using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController(IOrderService _orderService) : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return CreateResponse(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return CreateResponse(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var result = await _orderService.CreateOrder(createOrderDto);
            return CreateResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            var result = await _orderService.UpdateOrder(updateOrderDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            return CreateResponse(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersWithDetail()
        {
            var orders = await _orderService.GetAllOrdersWithDetail();
            return CreateResponse(orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatusHazir(int id)
        {
            var result = await _orderService.UpdateOrderStatusHazir(id);
            return CreateResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatusTeslim(int id)
        {
            var result = await _orderService.UpdateOrderStatusTeslimEdildi(id);
            return CreateResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatusIptal(int id)
        {
            var result = await _orderService.UpdateOrderStatusIptal(id);
            return CreateResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderStatusOdendi(int id)
        {
            var result = await _orderService.UpdateOrderStatusOdendi(id);
            return CreateResponse(result);
        }

        [HttpPatch]
        public async Task<IActionResult> AddOrderItemByOrderId(AddOrderItemByOrderIdDto dto)
        {
            var result = await _orderService.AddOrderItemByOrderId(dto);
            return CreateResponse(result);
        }
    }
}
