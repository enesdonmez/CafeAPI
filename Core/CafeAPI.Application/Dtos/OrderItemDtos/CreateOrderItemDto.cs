using CafeAPI.Application.Dtos.MenuItemDtos;

namespace CafeAPI.Application.Dtos.OrderItemDtos
{
    public class CreateOrderItemDto
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        //public decimal Price { get; set; }
    }
}
