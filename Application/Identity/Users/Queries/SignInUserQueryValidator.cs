using FluentValidation;

namespace Application.Identity.Users.Queries
{
    public class SignInUserQueryValidator:AbstractValidator<SignInUserQuery>
    {
        public SignInUserQueryValidator()
        {
            RuleFor(user => user.Username).NotEmpty().MaximumLength(250);
            RuleFor(user => user.Password).NotEmpty().MaximumLength(250);
        }
    }
}
