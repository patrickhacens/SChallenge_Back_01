using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Events.DetailEvent
{
    public class DetailEventRequest : IRequest<ResultOf<EventDetailDTO>>
    {
        public int Id { get; set; }
    }
}
