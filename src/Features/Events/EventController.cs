using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Features.Events.CreateEvent;
using SChallenge.Features.Events.DeleteEvent;
using SChallenge.Features.Events.DetailEvent;
using SChallenge.Features.Events.EditEvent;
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

        /// <summary>
        /// Simple list of events ordered by date.
        /// </summary>
        /// <param name="listEventsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Paginated list with events</returns>
        [HttpGet]
        public Task<ResultOf<PageResult<EventSimpleDTO>>> ListEvent([FromQuery]ListEventsRequest listEventsRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(listEventsRequest, cancellationToken);
        }

        /// <summary>
        /// Gets the details of specified Event Id.
        /// </summary>
        /// <param name="detailEventsRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code ="200"> User detail</response>
        /// <response code ="401"> User not found</response>
        [HttpGet("{Id}")]
        public Task<ResultOf<EventDetailDTO>> DetailEvent([FromRoute] DetailEventRequest detailEventsRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(detailEventsRequest, cancellationToken);
        }

        /// <summary>
        /// Creates an event setting the creator as the user who is creating it. This endpoint requires authentication.
        /// </summary>
        /// <param name="createEventRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST / Event
        ///     {
        ///         "name": "Entrega Senai Challenge",
        ///         "numOfParticipants": 10,
        ///         "date": "03/05/2022",
        ///         "time": "18:00",
        ///         "duration": 1
        ///     }
        /// </remarks>
        /// <response code ="200"> Event Id</response>
        /// <response code ="401"> User not authenticated</response>
        /// <response code ="400"> Date ou Time with invalid format</response>
        [Authorize]
        [HttpPost]
        public Task<ResultOf<int>> CreateEvent(CreateEventRequest createEventRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(createEventRequest, cancellationToken);
        }

        /// <summary>
        /// Edit and event. Can be edited only by its creator. This endpoint requires authentication.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="editEventRequestDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT / Event / {Id}
        ///     {
        ///         "name": "Entrega Senai Challenge",
        ///         "numOfParticipants": 10,
        ///         "date": "03/05/2022",
        ///         "time": "18:00",
        ///         "duration": 1
        ///     }
        /// </remarks>
        /// <response code ="200"> Event Id</response>
        /// <response code ="401"> User not authenticated or unauthorized</response>
        /// <response code ="400"> Date ou Time with invalid format</response>
        [Authorize]
        [HttpPut("{Id}")]
        public Task<Result> EditEvent(int Id, EditEventRequestDTO editEventRequestDTO, CancellationToken cancellationToken)
        {
            EditEventRequest editEventRequest = new()
            {
                Id = Id,
                EditEventRequestDTO = editEventRequestDTO
            };

            return mediator.Send(editEventRequest, cancellationToken);
        }

        /// <summary>
        /// Delete and event. Can be deleted only by its creator. This endpoint requires authentication.
        /// </summary>
        /// <param name="deleteEventRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code ="200"> Event Id</response>
        /// <response code ="401"> User not authenticated or unauthorized</response>
        [Authorize]
        [HttpDelete("{Id}")]
        public Task<Result> DeleteEvent([FromRoute]DeleteEventRequest deleteEventRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(deleteEventRequest, cancellationToken);
        }
    }
}
