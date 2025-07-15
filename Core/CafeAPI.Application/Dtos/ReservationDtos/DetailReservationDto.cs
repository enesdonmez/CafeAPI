namespace CafeAPI.Application.Dtos.ReservationDtos
{
    public class DetailReservationDto
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public int CafeId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
    }
}
