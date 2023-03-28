using EventManager.API.Models.Events;
using FluentValidation;

namespace EventManager.API.Validations.Events
{
    public class GetAllByUserIdRequestModelValidator : AbstractValidator<GetAllByUserIdRequestModel>
    {
        public GetAllByUserIdRequestModelValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
