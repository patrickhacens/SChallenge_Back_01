using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Authentication
{
    public class LoginRequest : IRequest<ResultOf<AuthenticationResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
