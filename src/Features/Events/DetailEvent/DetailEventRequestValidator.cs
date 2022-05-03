using FluentValidation;

namespace SChallenge.Features.Events.DetailEvent
{
    public class DetailEventRequestValidator : AbstractValidator<DetailEventRequest>
    {
        public DetailEventRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
