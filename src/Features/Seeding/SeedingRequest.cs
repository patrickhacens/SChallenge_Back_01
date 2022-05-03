using MediatR;
using Nudes.Retornator.Core;

namespace SChallenge.Features.Seeding
{
    public class SeedingRequest : IRequest<Result>
    {
        public int AmountOfUsers { get; set; }
        public int AmountOfEvents { get; set; }
    }
}
