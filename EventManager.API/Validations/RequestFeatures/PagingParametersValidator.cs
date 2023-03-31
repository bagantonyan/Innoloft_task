using EventManager.Shared.RequestFeatures;
using FluentValidation;

namespace EventManager.API.Validations.RequestFeatures
{
    public class PagingParametersValidator : AbstractValidator<PagingParameters>
    {
        public PagingParametersValidator()
        {
            RuleFor(p => p.PageNumber)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.PageSize)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}