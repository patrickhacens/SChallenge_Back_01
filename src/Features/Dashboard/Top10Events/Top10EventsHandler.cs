using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.Top10Events
{
    public class Top10EventsHandler : IRequestHandler<Top10EventsRequest, ResultOf<List<TopEvents>>>
    {
        private readonly EventManagerContext db;

        public Top10EventsHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<List<TopEvents>>> Handle(Top10EventsRequest request, CancellationToken cancellationToken)
        {
            return await db.Events
                .OrderByDescending(x => x.NumOfParticipants)
                .Take(10)
                .Select(x => new TopEvents()
                {
                    Id = x.Id,
                    EventName = x.Name,
                    NumOfParticipants = x.NumOfParticipants,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
