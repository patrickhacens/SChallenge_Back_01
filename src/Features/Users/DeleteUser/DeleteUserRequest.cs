using MediatR;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Users.DeleteUser
{
    public class DeleteUserRequest : IRequest<Result>
    {
        public int Id { get; set; }

    }
}
