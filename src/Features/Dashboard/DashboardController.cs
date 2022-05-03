using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;
using SChallenge.Features.Dashboard.EventsPerMonth;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard
{

    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator mediator;

        public DashboardController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("EventsPerMonthOfAYear")]
        public Task<ResultOf<List<EventsPerMonthDTO>>> EventsPerMonth([FromQuery]EventsPerMonthRequest eventsPerMonthRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(eventsPerMonthRequest, cancellationToken);
        }
    }
}
