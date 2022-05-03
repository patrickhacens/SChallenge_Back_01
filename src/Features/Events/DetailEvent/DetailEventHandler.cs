using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Events.DetailEvent
{
    public class DetailEventHandler : IRequestHandler<DetailEventRequest, ResultOf<EventDetailDTO>>
    {
        private readonly EventManagerContext db;

        public DetailEventHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<EventDetailDTO>> Handle(DetailEventRequest request, CancellationToken cancellationToken)
        {
            var ev = await db.Events.Include(x => x.Creator).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (ev == null)
                return new NotFoundError();

            var returningEvent = ev.Adapt<EventDetailDTO>();

            returningEvent.CreatorName = ev.Creator.Name;

            return returningEvent;
        }
    }
}
