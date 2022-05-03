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

        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Authentication Result with JWT Token</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST / Authentication
        ///     {
        ///         "email": "lucas@gmail.com",
        ///         "password": "123abc"
        ///     }
        /// </remarks>
        /// <response code ="200"> JWT Access Token</response>
        /// <response code ="401"> Wrong Email ou Password</response>
        [HttpPost]
        [AllowAnonymous]
        public Task<ResultOf<AuthenticationResult>> Login([FromBody] LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(loginRequest, cancellationToken);
        }
    }
}
