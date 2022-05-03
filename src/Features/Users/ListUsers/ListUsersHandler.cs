using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Paginator.Core;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;

namespace SChallenge.Features.Users.ListUsers
{
    public class ListUsersHandler : IRequestHandler<ListUserRequest, ResultOf<PageResult<UserDTO>>>
    {
        private readonly EventManagerContext db;

        public ListUsersHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<PageResult<UserDTO>>> Handle(ListUserRequest request, CancellationToken cancellationToken)
        {
            var user = db.Users.AsQueryable().Where(x => x.UserActive == true);

            if (!String.IsNullOrWhiteSpace(request.Search))
            {
                user = user.Where(u => u.Name.Contains(request.Search));
            }

            var total = await user.CountAsync(cancellationToken);

            List<UserDTO> list = await user.ProjectToType<UserDTO>().PaginateBy(request, p => p.Name).ToListAsync(cancellationToken);

            return new PageResult<UserDTO>(request, total, list);
        }
    }
}
