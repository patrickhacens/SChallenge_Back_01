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

        /// <summary>
        /// List active users registered in the database. Can filter by name with 'Search' param.
        /// </summary>
        /// <param name="ListUserRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Returns a paginated list of users</returns>
        [HttpGet]
        public Task<ResultOf<PageResult<UserDTO>>> GetAll([FromQuery] ListUserRequest ListUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(ListUserRequest, cancellationToken);
        }

        /// <summary>
        /// Register an user.
        /// </summary>
        /// <param name="createUserRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<ResultOf<int>> CreateClient([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(createUserRequest, cancellationToken);
        }

        /// <summary>
        /// Set user as inactive.
        /// </summary>
        /// <param name="deleteUserRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <response code ="200"> User set as inactive</response>
        /// <response code ="401"> User not found</response>
        [HttpDelete("{Id}")]
        public Task<Result> Delete([FromRoute] DeleteUserRequest deleteUserRequest, CancellationToken cancellationToken)
        {
            return mediator.Send(deleteUserRequest, cancellationToken);
        }
    }
}
