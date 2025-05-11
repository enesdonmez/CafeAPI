using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IOrderItemItemService
    {
        Task<ResponseDto<List<ResultOrderItemDto>>> GetAllOrderItems();
        Task<ResponseDto<DetailOrderItemDto>> GetOrderItemById(int id);
        Task<ResponseDto<object>> CreateOrderItem(CreateOrderItemDto createOrderItemDto);
        Task<ResponseDto<object>> UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto);
        Task<ResponseDto<object>> DeleteOrderItem(int id);
    }
}
