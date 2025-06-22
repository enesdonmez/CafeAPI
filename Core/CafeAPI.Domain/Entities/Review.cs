namespace CafeAPI.Domain.Entities
{
    public class Review : BaseEntity
    {
        public string UserId { get; set; }
        public int CafeId { get; set; }
        public CafeInfo CafeInfo { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
