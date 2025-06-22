using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.ReviewDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IReviewService
    {
        Task<ResponseDto<List<ResultReviewDto>>> GetAllReviews();
        Task<ResponseDto<DetailReviewDto>> GetReviewById(int id);
        Task<ResponseDto<object>> AddReview(CreateReviewDto createReviewDto);
        Task<ResponseDto<object>> UpdateReview(UpdateReviewDto updateReviewDto);
        Task<ResponseDto<object>> RemoveReview(int id);
    }
}
