using FluentValidation;

namespace SChallenge.Features.Dashboard.EventsPerMonth
{
    public class EventsPerMonthRequestValidator : AbstractValidator<EventsPerMonthRequest>
    {
        public EventsPerMonthRequestValidator()
        {
            RuleFor(x => x.Year)
                .NotEmpty();    
        }
    }
}
