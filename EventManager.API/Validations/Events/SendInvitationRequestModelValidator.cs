using EventManager.API.Models.Invitations;
using FluentValidation;

namespace EventManager.API.Validations.Events
{
    public class SendInvitationRequestModelValidator : AbstractValidator<SendInvitationRequestModel>
    {
        public SendInvitationRequestModelValidator()
        {
            RuleFor(p => p.EventId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.SenderId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.ReceiverIds)
                .NotEmpty()
                .NotNull();
        }
    }
}
