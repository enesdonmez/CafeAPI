using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

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
        Task<ResponseDto<object>> UpdateOrderStatusHazir(int id);
        Task<ResponseDto<object>> UpdateOrderStatusTeslimEdildi(int id);
        Task<ResponseDto<object>> UpdateOrderStatusIptal(int id);
        Task<ResponseDto<object>> UpdateOrderStatusOdendi(int id);
        Task<ResponseDto<object>> AddOrderItemByOrderId(AddOrderItemByOrderIdDto addOrderItemByOrderIdDto);

    }
}
