using FluentValidation;
using RestfulApi.EntityLayer.Entities;

namespace RestfulApi.Validators.LanguageValidators
{
    public class DeleteLanguageValidator : AbstractValidator<Language>
    {
        public DeleteLanguageValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id 0'dan büyük olmamalıdır !");
        }
    }
}
