using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Events.ListEvents
{
    public class ListEventsRequest :PageRequest, IRequest<ResultOf<PageResult<EventSimpleDTO>>>
    {
        public string MinDate { get; set; }
        public string MaxDate { get; set; }

    }
}
