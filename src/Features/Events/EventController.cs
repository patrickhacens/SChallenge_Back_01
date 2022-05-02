using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;
using SChallenge.Features.Events.CreateEvent;

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

        [Authorize]
        [HttpPost]
        public Task<ResultOf<int>> OrderPizza(CreateEventRequest createEventRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(createEventRequest, cancellationToken);
        }
    }
}
