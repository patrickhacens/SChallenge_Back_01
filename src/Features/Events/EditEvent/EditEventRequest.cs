using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nudes.Retornator.Core;
using SChallenge.Models;

namespace SChallenge.Features.Events.EditEvent
{
    public class EditEventRequest : IRequest<Result>
    {
        public int Id { get; set; }
        public EditEventRequestDTO EditEventRequestDTO { get; set; }
    }
}
