using Mapster;
using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Domain;

namespace SChallenge.Features.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, ResultOf<int>>
    {
        private readonly EventManagerContext db;

        public CreateUserHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<ResultOf<int>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.Adapt<User>();

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            db.Users.Add(user);

            await db.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
