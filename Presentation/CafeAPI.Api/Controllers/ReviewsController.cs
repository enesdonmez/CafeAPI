using CafeAPI.Application.Dtos.ReviewDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CafeAPI.Api.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController(IReviewService _reviewService) : BaseController
    {
        [EndpointDescription("Yorumları listeler.")]
        [ProducesResponseType<IList<ResultReviewDto>>(StatusCodes.Status200OK, "application/json")]
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return CreateResponse(reviews);
        }

        [EndpointDescription("ID ye göre yorumu getirir.")]
        [ProducesResponseType<IList<DetailReviewDto>>(StatusCodes.Status200OK, "application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            return CreateResponse(review);
        }

        [EndpointDescription("Yorum ekler.")]
        [ProducesResponseType<IList<CreateReviewDto>>(StatusCodes.Status200OK, "application/json")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto createReviewDto)
        {
            var result = await _reviewService.AddReview(createReviewDto);
            return CreateResponse(result);
        }

        [EndpointDescription("Yorumu günceller.")]
        [ProducesResponseType<IList<UpdateReviewDto>>(StatusCodes.Status200OK, "application/json")]
        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto updateReviewDto)
        {
            var result = await _reviewService.UpdateReview(updateReviewDto);
            return CreateResponse(result);
        }

        [EndpointDescription("ID ye göre yorumu siler.")]
        [ProducesResponseType<int>(StatusCodes.Status200OK, "application/json")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await _reviewService.RemoveReview(id);
            return CreateResponse(result);
        }
    }
}

