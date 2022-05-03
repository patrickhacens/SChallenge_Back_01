using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;
using SChallenge.Features.Dashboard.EventsPerMonth;
using SChallenge.Features.Dashboard.EventsPerUser;
using SChallenge.Features.Dashboard.Top10Events;
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

        [HttpGet("EventsPerUser")]
        public Task<ResultOf<List<EventsPerUserDTO>>> EventsPerUser([FromQuery]EventsPerUserRequest eventsPerUSerRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(eventsPerUSerRequest, cancellationToken);
        }

        [HttpGet("Top10Events")]
        public Task<ResultOf<List<TopEvents>>> Top10Events([FromQuery] Top10EventsRequest top10EventsRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(top10EventsRequest, cancellationToken);
        }
    }
}
