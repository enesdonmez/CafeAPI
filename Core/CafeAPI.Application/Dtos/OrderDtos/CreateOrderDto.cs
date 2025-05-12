using CafeAPI.Application.Dtos.OrderItemDtos;
using CafeAPI.Domain.Entities;

namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
