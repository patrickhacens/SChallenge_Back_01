using Bogus;
using MediatR;
using Nudes.Retornator.Core;
using SChallenge.Domain;

namespace SChallenge.Features.Seeding
{
    public class SeedingHandler : IRequestHandler<SeedingRequest, Result>
    {
        private readonly EventManagerContext db;

        public SeedingHandler(EventManagerContext db)
        {
            this.db = db;
        }
        public async Task<Result> Handle(SeedingRequest request, CancellationToken cancellationToken)
        {
            CleanDB(cancellationToken);
            SeedUsersAndEvents(request.AmountOfUsers, request.AmountOfEvents);
            await db.SaveChangesAsync(cancellationToken);

            return Result.Success;
        }


        private async void CleanDB(CancellationToken cancellationToken)
        {
            db.Events.RemoveRange(db.Events.Select(x => x));
            db.Users.RemoveRange(db.Users.Select(x => x));
            await db.SaveChangesAsync(cancellationToken);
        }
        private void SeedUsersAndEvents(int amountOfUsers, int amountOfEvents)
        {
            string password = "123abc";

            var user = new Faker<User>()
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.Name))
                .RuleFor(x => x.PasswordHash, f => BCrypt.Net.BCrypt.HashPassword(password))
                .RuleFor(x => x.UserActive, f => true);

            List<User> Users = user.Generate(amountOfUsers);

            db.Users.AddRange(Users);

            List<Event> Events = new();

            var Event = new Faker<Event>()
                .RuleFor(x => x.Name, f => f.Lorem.Sentence())
                .RuleFor(x => x.Duration, f => f.Random.Int(1, 6))
                .RuleFor(x => x.Creator, f => f.PickRandom(Users))
                .RuleFor(x => x.Date, f => f.Date.Between(DateTime.Parse("01/01/2000"), DateTime.Parse("31/12/2022")))
                .RuleFor(x => x.NumOfParticipants, f => f.Random.Int(100, 1000));

            Events = Event.Generate(amountOfEvents);

            db.Events.AddRange(Events);
        }
    }
}
