using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Features.Events.CreateEvent;
using SChallenge.Features.Events.ListEvents;
using SChallenge.Models;

namespace SChallenge.Features.Events
{

    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IMediator mediator;

        public EventController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<ResultOf<PageResult<EventSimpleDTO>>> ListEvent([FromQuery]ListEventsRequest listEventsRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(listEventsRequest, cancellationToken);
        }

        [Authorize]
        [HttpPost]
        public Task<ResultOf<int>> CreateEvent(CreateEventRequest createEventRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(createEventRequest, cancellationToken);
        }
    }
}
