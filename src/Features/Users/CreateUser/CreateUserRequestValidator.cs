using FluentValidation;

namespace SChallenge.Features.Users.CreateUser
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(p => p.Name)
                .NotEmpty();

            RuleFor(p => p.Password)
                .NotEmpty();
        }
    }
}
