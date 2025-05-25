using CafeAPI.Application.Dtos.UserDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.UserValidator;

public class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İsim alanı boş olamaz.")
            .MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır.");
        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Soyisim alanı boş olamaz.")
            .MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır.")
            .MaximumLength(50).WithMessage("Soyisim en fazla 50 karakter olmalıdır.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email alanı boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifre alanı boş olamaz.")
            .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.");
    }
}