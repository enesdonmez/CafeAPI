using CafeAPI.Application.Dtos.OrderItemDtos;

namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        //public decimal TotalPrice { get; set; }
        //public DateTime UpdateAt { get; set; } = DateTime.Now;
        //public string Status { get; set; }
        public List<UpdateOrderItemDto> OrderItems { get; set; }
    }
}
