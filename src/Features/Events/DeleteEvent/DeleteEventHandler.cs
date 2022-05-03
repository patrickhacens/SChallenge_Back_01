using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using System.Security.Claims;

namespace SChallenge.Features.Events.DeleteEvent
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, Result>
    {
        private readonly EventManagerContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DeleteEventHandler(EventManagerContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
        {
            var ev = await db.Events.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (ev == null)
                return new NotFoundError();

            var creatorId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            if (ev.CreatorId != creatorId)
            {
                return new ForbiddenError();
            }

            db.Events.Remove(ev);
            await db.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }
    }
}
