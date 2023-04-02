using EventManager.API.Models.Events;
using FluentValidation;

namespace EventManager.API.Validations.Events
{
    public class ParticipateRequestModelValidator : AbstractValidator<ParticipateRequestModel>
    {
        public ParticipateRequestModelValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.EventId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}