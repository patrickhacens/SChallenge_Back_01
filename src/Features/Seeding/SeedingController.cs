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

        /// <summary>
        /// Clear previous database and seeds it with a desired amount of random users and events.
        /// </summary>
        /// <param name="seedingRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<Result> Seeding(SeedingRequest seedingRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(seedingRequest, cancellationToken);
        }
    }
}
