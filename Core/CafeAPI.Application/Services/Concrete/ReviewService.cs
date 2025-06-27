using AutoMapper;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.ReviewDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using CafeAPI.Domain.Entities;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReviewDto> _createReviewValidator;
        private readonly IValidator<UpdateReviewDto> _updateReviewValidator;

        public ReviewService(IMapper mapper, IValidator<CreateReviewDto> createReviewValidator, IValidator<UpdateReviewDto> updateReviewValidator, IGenericRepository<Review> reviewRepository)
        {
            _mapper = mapper;
            _createReviewValidator = createReviewValidator;
            _updateReviewValidator = updateReviewValidator;
            _reviewRepository = reviewRepository;
        }

        public async Task<ResponseDto<object>> AddReview(CreateReviewDto createReviewDto)
        {
            try
            {
                var validationResult = await _createReviewValidator.ValidateAsync(createReviewDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage).ToList()),
                        ErrorCode = ErrorCodes.ValidationError,

                    };
                }

                var review = _mapper.Map<Review>(createReviewDto);
                review.CreatedAt = DateTime.Now;
                await _reviewRepository.AddAsync(review);
                return new ResponseDto<object>
                {
                    IsSuccess = true,
                    Data = review,
                    Message = "Yorum başarıyla eklendi.",
                };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<List<ResultReviewDto>>> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewRepository.GetAllAsync();
                if (reviews == null || !reviews.Any())
                {
                    return new ResponseDto<List<ResultReviewDto>> 
                    { IsSuccess = false, Data = null, Message = "Yorum bulunamadı.", ErrorCode = ErrorCodes.NotFound };
                }

                var resultReviews = _mapper.Map<List<ResultReviewDto>>(reviews);
                return new ResponseDto<List<ResultReviewDto>>
                { IsSuccess = true, Data = resultReviews, Message = "Yorumlar başarıyla getirildi." };
            }
            catch (Exception)
            {

                return new ResponseDto<List<ResultReviewDto>> 
                { IsSuccess = false, Data = null, Message = "bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<DetailReviewDto>> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(id);
                if (review == null)
                {
                    return new ResponseDto<DetailReviewDto>
                    { IsSuccess = false, Data = null, Message = "Yorum bulunamadı.", ErrorCode = ErrorCodes.NotFound };
                }
                var detailReview = _mapper.Map<DetailReviewDto>(review);
                return new ResponseDto<DetailReviewDto>
                { IsSuccess = true, Data = detailReview, Message = "Yorum başarıyla getirildi." };
            }
            catch (Exception)
            {

                return new ResponseDto<DetailReviewDto>
                { IsSuccess = false, Data = null, Message = "bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> RemoveReview(int id)
        {
            try
            {
                var review = await _reviewRepository.GetByIdAsync(id);
                if (review == null)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Yorum bulunamadı.", ErrorCode = ErrorCodes.NotFound };
                }
                await _reviewRepository.DeleteAsync(review);
                return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Yorum başarıyla silindi." };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> UpdateReview(UpdateReviewDto updateReviewDto)
        {
            try
            {
                var validationResult = await _updateReviewValidator.ValidateAsync(updateReviewDto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = string.Join(",", validationResult.Errors.Select(e => e.ErrorMessage).ToList()),
                        ErrorCode = ErrorCodes.ValidationError,
                    };
                }
                var review = await _reviewRepository.GetByIdAsync(updateReviewDto.Id);
                if (review == null)
                {
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Yorum bulunamadı.", ErrorCode = ErrorCodes.NotFound };
                }
                _mapper.Map(updateReviewDto, review);
                await _reviewRepository.UpdateAsync(review);
                return new ResponseDto<object> { IsSuccess = true, Data = review, Message = "Yorum başarıyla güncellendi." };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "bir hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }
    }
}
