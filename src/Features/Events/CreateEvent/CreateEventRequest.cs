using MediatR;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Events.CreateEvent
{
    public class CreateEventRequest : IRequest<ResultOf<int>>
    {
        public string Name { get; set; }
        public int NumOfParticipants { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Duration { get; set; }
    }
}
