using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using System.Security.Claims;

namespace SChallenge.Features.Events.EditEvent
{
    public class EditEventHandler : IRequestHandler<EditEventRequest, Result>
    {
        private readonly EventManagerContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EditEventHandler(EventManagerContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result> Handle(EditEventRequest request, CancellationToken cancellationToken)
        {
            var ev = await db.Events.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(ev == null)
                return new NotFoundError();

            var creatorId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
            if (ev.CreatorId != creatorId)
            {
                return new ForbiddenError();
            }
            string datetime = $"{request.EditEventRequestDTO.Date} {request.EditEventRequestDTO.Time}";

            DateTime date = new();
            if (!DateTime.TryParse(datetime, out date))
            {
                return new BadRequestError().AddFieldErrors($"{nameof(request.EditEventRequestDTO.Date)} and/or {nameof(request.EditEventRequestDTO.Time)}", "Invalid format for 'date' or 'time'.");
            };

            ev.Date = date;
            ev.Name = request.EditEventRequestDTO.Name;
            ev.Duration = request.EditEventRequestDTO.Duration;
            ev.NumOfParticipants = request.EditEventRequestDTO.NumOfParticipants;

            await db.SaveChangesAsync(cancellationToken);

            return Result.Success;

        }
    }
}
