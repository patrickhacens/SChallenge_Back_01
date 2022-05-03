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

        /// <summary>
        /// Amount of events held per month in a specific year.
        /// </summary>
        /// <param name="eventsPerMonthRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list with each month and its events amount</returns>
        [HttpGet("EventsPerMonthOfAYear")]
        public Task<ResultOf<List<EventsPerMonthDTO>>> EventsPerMonth([FromQuery]EventsPerMonthRequest eventsPerMonthRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(eventsPerMonthRequest, cancellationToken);
        }

        /// <summary>
        /// Amount of events held per user.
        /// </summary>
        /// <param name="eventsPerUSerRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list with each user and its events amount</returns>
        [HttpGet("EventsPerUser")]
        public Task<ResultOf<List<EventsPerUserDTO>>> EventsPerUser([FromQuery]EventsPerUserRequest eventsPerUSerRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(eventsPerUSerRequest, cancellationToken);
        }

        /// <summary>
        /// Top 10 events with the biggest number of participants.
        /// </summary>
        /// <param name="top10EventsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a list with 10 events with the biggets number of participants</returns>
        [HttpGet("Top10Events")]
        public Task<ResultOf<List<TopEvents>>> Top10Events([FromQuery] Top10EventsRequest top10EventsRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(top10EventsRequest, cancellationToken);
        }
    }
}
