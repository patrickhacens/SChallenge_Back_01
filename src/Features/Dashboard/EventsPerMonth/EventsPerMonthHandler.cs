using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.EventsPerMonth
{
    public class EventsPerMonthHandler : IRequestHandler<EventsPerMonthRequest, ResultOf<List<EventsPerMonthDTO>>>
    {
        private readonly EventManagerContext db;

        public EventsPerMonthHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<List<EventsPerMonthDTO>>> Handle(EventsPerMonthRequest request, CancellationToken cancellationToken)
        {
            return await db.Events
                .Where(x => x.Date.Year == request.Year)
                .GroupBy(x => x.Date.Month)
                .Select(x => new EventsPerMonthDTO()
                {
                    Month = x.Key,
                    Quantity = x.Count()
                })
                .OrderBy(x => x.Month)
                .ToListAsync(cancellationToken);
        }
    }
}
