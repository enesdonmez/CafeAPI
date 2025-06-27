using CafeAPI.Application.Dtos.ReviewDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController(IReviewService _reviewService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return CreateResponse(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            return CreateResponse(review);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto createReviewDto)
        {
            var result = await _reviewService.AddReview(createReviewDto);
            return CreateResponse(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto updateReviewDto)
        {
            var result = await _reviewService.UpdateReview(updateReviewDto);
            return CreateResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.RemoveReview(id);
            return CreateResponse(result);
        }
    }
}

