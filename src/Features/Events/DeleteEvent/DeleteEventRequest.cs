using MediatR;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Events.DeleteEvent
{
    public class DeleteEventRequest : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
