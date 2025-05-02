using CafeAPI.Application.Dtos.CategoryDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.CategoryValidator;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("Kategori adı boş olamaz")
            .Length(3, 30).WithMessage("Kategori adı 3 ile 30 karakter arasında olmalıdır");
    }
}
