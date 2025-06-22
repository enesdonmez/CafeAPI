using CafeAPI.Application.Dtos.ReviewDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.ReviewValidator
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Yorum boş olamaz")
                .MaximumLength(500).WithMessage("Yorum en fazla 500 karakter olabilir");

            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Derece boş olamaz")
                .InclusiveBetween(1, 5).WithMessage("Derece 1 ile 5 arasında olmak zorunda");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı ID boş olamaz");

            RuleFor(x => x.CafeId)
                .NotEmpty().WithMessage("Kafe ID boş olamaz");
        }
    }
}
