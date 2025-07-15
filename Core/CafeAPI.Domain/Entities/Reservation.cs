namespace CafeAPI.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public string Status { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int CafeId { get; set; }
        public CafeInfo CafeInfo { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfPeople { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
