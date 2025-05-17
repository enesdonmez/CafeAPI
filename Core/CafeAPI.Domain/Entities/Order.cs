namespace CafeAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int TableId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
