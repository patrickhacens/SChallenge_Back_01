using MediatR;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Users.CreateUser
{
    public class CreateUserRequest : IRequest<ResultOf<int>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
