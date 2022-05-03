using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.EventsPerMonth
{
    public class EventsPerMonthRequest : IRequest<ResultOf<List<EventsPerMonthDTO>>>
    {
        public int Year { get; set; }
    }
}
