namespace CafeAPI.Application.Dtos.ReviewDtos
{
    public class ResultReviewDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CafeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
