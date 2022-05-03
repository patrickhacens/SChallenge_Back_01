using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.EventsPerUser
{
    public class EventsPerUserRequest : IRequest<ResultOf<List<EventsPerUserDTO>>>
    {
    }
}
