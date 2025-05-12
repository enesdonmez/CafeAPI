namespace CafeAPI.Application.Dtos.OrderDtos
{
    public class ResultOrderByIdWithDetailDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string MenuItemName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
