using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Seeding
{
    [ApiController]
    [Route("[controller]")]
    public class SeedingController : ControllerBase
    {
        private readonly IMediator mediator;

        public SeedingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<Result> Seeding(SeedingRequest seedingRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(seedingRequest, cancellationToken);
        }
    }
}
