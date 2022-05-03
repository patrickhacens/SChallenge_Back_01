using FluentValidation;

namespace SChallenge.Features.Events.EditEvent
{
    public class EditEventRequestValidator : AbstractValidator<EditEventRequest>
    {
        public EditEventRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
