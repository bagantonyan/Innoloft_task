using EventManager.API.Models.Events;
using FluentValidation;

namespace EventManager.API.Validations.Events
{
    public class DeleteEventRequestModelValidator : AbstractValidator<DeleteEventRequestModel>
    {
        public DeleteEventRequestModelValidator()
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