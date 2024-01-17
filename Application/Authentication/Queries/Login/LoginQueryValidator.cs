using FluentValidation;

namespace Application.Authentication.Queries.Login;

public class LoginQueryValidator: AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(50);
    }
}