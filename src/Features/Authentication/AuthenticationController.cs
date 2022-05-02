using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Authentication
{

    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<ResultOf<AuthenticationResult>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(loginRequest, cancellationToken);
        }
    }
}
