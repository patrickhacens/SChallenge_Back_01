using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Dashboard.Top10Events
{
    public class Top10EventsRequest : IRequest<ResultOf<List<TopEvents>>>
    {
    }
}
