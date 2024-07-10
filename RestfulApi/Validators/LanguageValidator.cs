using FluentValidation;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.Validators
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Length(3,50);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.DifficultyLevel)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(1, 5);

            RuleFor(x => x.IsPopular)
                .NotNull()
                .NotEmpty();
        }
    }
}
