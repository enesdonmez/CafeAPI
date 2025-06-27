namespace CafeAPI.Application.Dtos.ReviewDtos
{
    public class CreateReviewDto
    {
        public string UserId { get; set; }
        public int CafeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
