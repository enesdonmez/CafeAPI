using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IOrderService
    {
        Task<ResponseDto<List<ResultOrderDto>>> GetAllOrders();
        Task<ResponseDto<ResultOrderByIdWithDetailDto>> GetOrderById(int id);
        Task<ResponseDto<object>> CreateOrder(CreateOrderDto createOrderDto);
        Task<ResponseDto<object>> UpdateOrder(UpdateOrderDto updateOrderDto);
        Task<ResponseDto<object>> DeleteOrder(int id);
        Task<ResponseDto<List<ResultOrderDto>>> GetAllOrdersWithDetail();

    }
}
