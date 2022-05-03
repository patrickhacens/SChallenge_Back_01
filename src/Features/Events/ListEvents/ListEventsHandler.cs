using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Paginator.Core;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Events.ListEvents
{
    public class ListEventsHandler : IRequestHandler<ListEventsRequest, ResultOf<PageResult<EventSimpleDTO>>>
    {
        private readonly EventManagerContext db;

        public ListEventsHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<PageResult<EventSimpleDTO>>> Handle(ListEventsRequest request, CancellationToken cancellationToken)
        {
            var events = db.Events.Include(x => x.Creator).AsQueryable();

            if (!String.IsNullOrWhiteSpace(request.MinDate))
            {
                var MinDate = new DateTime();
                if(!DateTime.TryParse(request.MinDate, out MinDate))
                {
                    return new BadRequestError().AddFieldErrors(nameof(request.MinDate), "Invalid format for 'MinDate'. ");
                }
                events = events.Where(x => x.Date >= MinDate);
            }
            
            if (!String.IsNullOrWhiteSpace(request.MaxDate))
            {
                var MaxDate = new DateTime();
                if (!DateTime.TryParse(request.MaxDate, out MaxDate))
                {
                    return new BadRequestError().AddFieldErrors(nameof(request.MaxDate), "Invalid format for 'MaxDate'. ");
                }
                events = events.Where(x => x.Date <= MaxDate);
            }

            var total = await events.CountAsync(cancellationToken);

            var list = await events.ProjectToType<EventSimpleDTO>().PaginateBy(request, p => p.Date).ToListAsync(cancellationToken);

            return new PageResult<EventSimpleDTO>(request, total, list);
        }
    }
}
