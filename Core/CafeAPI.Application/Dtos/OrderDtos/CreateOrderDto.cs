using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int TableId { get; set; }
        //public decimal TotalPrice { get; set; }
        //public DateTime UpdateAt { get; set; } = DateTime.Now;
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
