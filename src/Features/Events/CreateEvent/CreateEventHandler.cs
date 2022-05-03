﻿using Mapster;
using MediatR;
using Nudes.Retornator.AspnetCore.Errors;
using Nudes.Retornator.Core;
using SChallenge.Domain;
using System.Security.Claims;

namespace SChallenge.Features.Events.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, ResultOf<int>>
    {
        private readonly EventManagerContext db;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateEventHandler(EventManagerContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResultOf<int>> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            var ev = request.Adapt<Event>();

            string datetime = $"{request.Date} {request.Time}";

            DateTime date = new();
            if(!DateTime.TryParse(datetime,out date)){
                return new BadRequestError().AddFieldErrors($"{nameof(request.Date)}, {nameof(request.Time)}", "Invalid format for 'date' or 'time'.");
            };
            ev.Date = date;

            ev.CreatorId = int.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            db.Events.Add(ev);

            await db.SaveChangesAsync(cancellationToken);

            return ev.Id;
        }
    }
}
