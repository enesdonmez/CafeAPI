using CafeAPI.Application.Dtos.OrderItemDtos;

namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Status { get; set; }
        public List<ResultOrderItemDto> OrderItems { get; set; }
    }
}
