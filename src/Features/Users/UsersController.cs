using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Features.Users.CreateUser;
using SChallenge.Features.Users.DeleteUser;
using SChallenge.Features.Users.ListUsers;
using SChallenge.Models;

namespace SChallenge.Features.Users
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<ResultOf<PageResult<UserDTO>>> GetAll([FromQuery] ListUserRequest ListUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(ListUserRequest, cancellationToken);
        }

        [HttpPost]
        public Task<ResultOf<int>> CreateClient([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(createUserRequest, cancellationToken);
        }

        [HttpDelete("{Id}")]
        public Task<Result> Delete([FromRoute] DeleteUserRequest deleteUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(deleteUserRequest, cancellationToken);
        }
    }
}
