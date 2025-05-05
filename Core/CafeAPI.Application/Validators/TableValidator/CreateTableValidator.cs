using CafeAPI.Application.Dtos.TableDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.TableValidator
{
    public class CreateTableValidator : AbstractValidator<CreateTableDto>
    {
        public CreateTableValidator()
        {
            RuleFor(x => x.TableNumber)
                .NotEmpty()
                .WithMessage("Masa Numarası boş olamaz");
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage("Kapasite boş olamaz")
                .GreaterThan(0)
                .WithMessage("Kapasite 0'dan büyük olmalıdır.");
        }
    }
}
