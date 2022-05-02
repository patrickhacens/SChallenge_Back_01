using MediatR;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Users.ListUsers
{
    public class ListUserRequest : PageRequest, IRequest<ResultOf<PageResult<UserDTO>>>
    {
        public string Search { get; set; }

    }
}
