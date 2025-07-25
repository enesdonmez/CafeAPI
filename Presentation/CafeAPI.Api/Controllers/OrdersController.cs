﻿using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Authorize(Roles = "admin,employee")]
    [Route("api/orders")]
    [ApiController]
    public class OrdersController(IOrderService _orderService) : BaseController
    {
        [EndpointDescription("Siparişleri listeler.")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return CreateResponse(orders);
        }

        [EndpointDescription("Siparişi Id ye göre getirir.")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return CreateResponse(order);
        }

        [EndpointDescription("Sipariş ekler.")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            var result = await _orderService.CreateOrder(createOrderDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişi günceller.")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            var result = await _orderService.UpdateOrder(updateOrderDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişi siler.")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişleri detayları ile listeler.")]
        [HttpGet("detail")]
        public async Task<IActionResult> GetAllOrdersWithDetail()
        {
            var orders = await _orderService.GetAllOrdersWithDetail();
            return CreateResponse(orders);
        }

        [EndpointDescription("Siparişin durumunu hazır olarak günceller.")]
        [HttpPatch("{id}/status-hazir")]
        public async Task<IActionResult> UpdateOrderStatusHazir(int id)
        {
            var result = await _orderService.UpdateOrderStatusHazir(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişin durumunu teslim edildi olarak günceller.")]
        [HttpPatch("{id}/status-teslim")]
        public async Task<IActionResult> UpdateOrderStatusTeslim(int id)
        {
            var result = await _orderService.UpdateOrderStatusTeslimEdildi(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişin durumunu iptal olarak günceller.")]
        [HttpPatch("{id}/status-iptal")]
        public async Task<IActionResult> UpdateOrderStatusIptal(int id)
        {
            var result = await _orderService.UpdateOrderStatusIptal(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişin durumunu ödendi olarak günceller.")]
        [HttpPatch("{id}/status-odendi")]
        public async Task<IActionResult> UpdateOrderStatusOdendi(int id)
        {
            var result = await _orderService.UpdateOrderStatusOdendi(id);
            return CreateResponse(result);
        }

        [EndpointDescription("Siparişe yeni ürün ekler.")]
        [HttpPost("orderitems")]
        public async Task<IActionResult> AddOrderItemByOrderId(AddOrderItemByOrderIdDto dto)
        {
            var result = await _orderService.AddOrderItemByOrderId(dto);
            return CreateResponse(result);
        }
    }
}
