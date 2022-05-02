using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using SChallenge.Models;
using SChallenge.Services;

namespace SChallenge.Features.Authentication
{
    public class LoginHandler : IRequestHandler<LoginRequest, ResultOf<AuthenticationResult>>
    {
        private readonly EventManagerContext db;
        private readonly TokenService tokenService;

        public LoginHandler(EventManagerContext db, TokenService tokenService)
        {
            this.db = db;
            this.tokenService = tokenService;
        }
        public async Task<ResultOf<AuthenticationResult>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
                return new UnauthorizedError();

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return new UnauthorizedError();

            return new AuthenticationResult()
            {
                AccessToken = tokenService.GenerateToken(user),
            };
        }
    }
}
