using CafeAPI.Application.Dtos.ReservationDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.ReservationValidator
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidator()
        {
            
            RuleFor(x => x.CustomerName)
                 .NotEmpty()
                 .WithMessage("Müşteri adı gereklidir.")
                 .MaximumLength(100)
                 .WithMessage("Müşteri adı 100 karakteri geçemez.");

            RuleFor(x => x.CustomerEmail)
                 .NotEmpty()
                 .WithMessage("Müşteri e-posta adresi gereklidir.")
                 .EmailAddress()
                 .WithMessage("Geçersiz e-posta formatı.");

            RuleFor(x => x.CustomerPhoneNumber)
                 .NotEmpty()
                 .WithMessage("Müşteri telefon numarası gereklidir.")
                 .Matches(@"^\+?[1-9]\d{1,14}$")
                 .WithMessage("Geçersiz telefon numarası formatı.");

            RuleFor(x => x.ReservationDate)
                 .NotEmpty()
                 .WithMessage("Rezervasyon tarihi gereklidir.")
                 .GreaterThan(DateTime.Now)
                 .WithMessage("Rezervasyon tarihi gelecekte olmalıdır.");

            RuleFor(x => x.NumberOfPeople)
                 .GreaterThan(0)
                 .WithMessage("Misafir sayısı sıfırdan büyük olmalıdır.");

            RuleFor(x => x.TableId)
                    .NotEmpty()
                    .WithMessage("Masa ID'si gereklidir.")
                    .GreaterThan(0)
                    .WithMessage("Masa ID'si sıfırdan büyük olmalıdır.");

            RuleFor(x => x.CafeId)
                    .NotEmpty()
                    .WithMessage("Kafe ID'si gereklidir.")
                    .GreaterThan(0)
                    .WithMessage("Kafe ID'si sıfırdan büyük olmalıdır.");
        }
    }
}
