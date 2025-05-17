using CafeAPI.Application.Dtos.OrderDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.OrderValidator;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.TableId)
            .NotEmpty()
            .WithMessage("Masa id girilmesi zorunludur.");
        RuleFor(x => x.OrderItems)
            .NotEmpty()
            .WithMessage("Sipariş öğeleri girilmesi zorunludur.");
      

    }
}
