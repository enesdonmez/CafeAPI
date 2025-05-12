using CafeAPI.Application.Dtos.OrderDtos;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersWithDetailAsync();
        Task<ResultOrderByIdWithDetailDto> GetOrderByIdWithDetailAsync(int id);
        
    }
}
