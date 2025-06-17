using CafeAPI.Application.Dtos.CafeInfoDtos;
using FluentValidation;

namespace CafeAPI.Application.Validators.CafeInfoValidator
{
    public class CreateCafeInfoValidator : AbstractValidator<CreateCafeInfoDto>
    {
        public CreateCafeInfoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kafe adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kafe adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(300).WithMessage("Görsel URL'si en fazla 300 karakter olabilir.");

            RuleFor(x => x.OpeningHours)
                .NotEmpty().WithMessage("Açılış saatleri boş olamaz.")
                .MaximumLength(100).WithMessage("Açılış saatleri bilgisi en fazla 100 karakter olabilir.");

            RuleFor(x => x.WebsiteUrl)
                .MaximumLength(200).WithMessage("Web sitesi URL'si en fazla 200 karakter olabilir.");

            RuleFor(x => x.InstagramUrl)
                .MaximumLength(200).WithMessage("Instagram URL'si en fazla 200 karakter olabilir.");

            RuleFor(x => x.FacebookUrl)
                .MaximumLength(200).WithMessage("Facebook URL'si en fazla 200 karakter olabilir.");

            RuleFor(x => x.TwitterUrl)
                .MaximumLength(200).WithMessage("Twitter URL'si en fazla 200 karakter olabilir.");

            RuleFor(x => x.YoutubeUrl)
                .MaximumLength(200).WithMessage("Youtube URL'si en fazla 200 karakter olabilir.");
        }
    }
}
