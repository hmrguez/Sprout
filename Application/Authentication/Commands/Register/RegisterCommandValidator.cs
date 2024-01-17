using FluentValidation;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(50);
    }
}