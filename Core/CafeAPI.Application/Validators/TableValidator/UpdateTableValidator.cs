using CafeAPI.Application.Dtos.TableDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.TableValidator;

public class UpdateTableValidator : AbstractValidator<UpdateTableDto>
{
    public UpdateTableValidator()
    {

        RuleFor(x => x.TableNumber)
            .NotEmpty()
            .WithMessage("Masa Numarası boş olamaz")
            .GreaterThan(0)
            .WithMessage("Kapasite 0'dan büyük olmalıdır.");
        RuleFor(x => x.Capacity)
               .NotEmpty()
               .WithMessage("Kapasite boş olamaz")
               .GreaterThan(0)
               .WithMessage("Kapasite 0'dan büyük olmalıdır.");

    }
}
