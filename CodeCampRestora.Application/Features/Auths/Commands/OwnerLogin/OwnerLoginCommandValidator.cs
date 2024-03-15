using FluentValidation;
using CodeCampRestora.Application.Common;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public class OwnerLoginCommandValidator : ApplicationValidator<OwnerLoginCommand>
{
    public OwnerLoginCommandValidator()
    {
        RuleFor(p => p.Username).EmailAddress().WithMessage("Please provide a valid email address");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Password must not be empty");
    }
}