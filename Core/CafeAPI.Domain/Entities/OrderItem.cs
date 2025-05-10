namespace CafeAPI.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}