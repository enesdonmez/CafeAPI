using CafeAPI.Application.Dtos.OrderItemDtos;

namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class AddOrderItemByOrderIdDto
    {
        public int OrderId { get; set; }
        public CreateOrderItemDto OrderItem { get; set; }
    }
}
