using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.EventsPerUser
{
    public class EventsPerUserHandler : IRequestHandler<EventsPerUserRequest, ResultOf<List<EventsPerUserDTO>>>
    {
        private readonly EventManagerContext db;

        public EventsPerUserHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<List<EventsPerUserDTO>>> Handle(EventsPerUserRequest request, CancellationToken cancellationToken)
        {
            return await db.Events
                .Include(x => x.Creator)
                .GroupBy(x => x.CreatorId)
                .Select(x => new EventsPerUserDTO()
                {
                    UserId = x.Key,
                    Quantity = x.Count(),
                    UserName = x.First().Creator.Name
                }).ToListAsync(cancellationToken);
        }
    }
}
