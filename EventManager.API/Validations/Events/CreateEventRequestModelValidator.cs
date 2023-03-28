using EventManager.API.Models.Events;
using FluentValidation;

namespace EventManager.API.Validations.Events
{
    public class CreateEventRequestModelValidator : AbstractValidator<CreateEventRequestModel>
    {
        public CreateEventRequestModelValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(10000);

            RuleFor(p => p.StartDate)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.EndDate)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.TimeZone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(p => p.Mode)
                .NotEmpty()
                .NotNull()
                .MaximumLength(8);

            RuleFor(p => p.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(p => p.Hidden)
                .NotEmpty()
                .NotNull();

            RuleFor(p => p.UserId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
