using CafeAPI.Application.Dtos.OrderItemDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.OrderItemValidator;

public class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemDto>
{
    public UpdateOrderItemValidator()
    {
       
        RuleFor(x => x.MenuItemId)
            .NotEmpty()
            .WithMessage("Menü öğesi id girilmesi zorunludur.");
        RuleFor(x => x.Quantity)
            .NotEmpty()
            .WithMessage("adet girilmesi zorunludur.")
            .GreaterThan(0)
            .WithMessage("adet 0 dan büyük olmalı.");
       
    }
}
