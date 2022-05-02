using Mapster;
using SChallenge.Domain;
using SChallenge.Features.Events.CreateEvent;

namespace SChallenge.Adapters
{
    public class EventAdapter : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateEventRequest, Event>()
                .Ignore(x => x.Date);
        }
    }
}
