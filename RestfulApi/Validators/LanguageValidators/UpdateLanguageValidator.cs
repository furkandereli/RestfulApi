using FluentValidation;
using RestfulApi.DtoLayer.DTOs.LanguageDtos;

namespace RestfulApi.Validators.LanguageValidators
{
    public class UpdateLanguageValidator : AbstractValidator<UpdateLanguageDto>
    {
        public UpdateLanguageValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id 0'dan büyük olmalıdır !");

            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(3,50)
                .WithMessage("Ad aralığı 3-50 olmalıdır !");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Açıklama uzunluğu maximum 200 olmalıdır.");

            RuleFor(x => x.DifficultyLevel)
                .NotEmpty()
                .InclusiveBetween(1, 5)
                .WithMessage("Zorluk derecesi 1-5 (dahil) aralığında olmalıdır !");

            RuleFor(x => x.IsPopular)
                .NotEmpty()
                .WithMessage("Popülerlik true false olarak ayarlanmalıdır !");

        }
    }
}
