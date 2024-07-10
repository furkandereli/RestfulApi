using FluentValidation;

namespace RestfulApi.Validators.LanguageValidators
{
    public class GetLanguageByIdValidator : AbstractValidator<int>
    {
        public GetLanguageByIdValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Id 0'dan büyük olmalıdır !");
        }
    }
}
