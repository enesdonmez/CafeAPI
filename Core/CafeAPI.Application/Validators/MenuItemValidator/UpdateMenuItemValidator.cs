using CafeAPI.Application.Dtos.MenuItemDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.MenuItemValidator;

public class UpdateMenuItemValidator : AbstractValidator<UpdateMenuItemDto>
{
    public UpdateMenuItemValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("İsim boş olamaz.");
        RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Fiyat boş olamaz.");
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Fiyat 0 dan küçük olamaz.");
        RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Açıklama boş olamaz.");
        RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("Kategori Id boş olamaz.");
    }
}
