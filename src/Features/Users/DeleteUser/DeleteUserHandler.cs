using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;

namespace SChallenge.Features.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result>
    {
        private readonly EventManagerContext db;

        public DeleteUserHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await db.Users.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (user is null)
                return new NotFoundError();


            db.Users.Remove(user);
            await db.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
