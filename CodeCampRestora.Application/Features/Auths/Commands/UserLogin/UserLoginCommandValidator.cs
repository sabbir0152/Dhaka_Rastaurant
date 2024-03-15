using FluentValidation;
using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Features.Auths.Commands.UserLogin;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public class UserLoginCommandValidator : ApplicationValidator<UserLoginCommand>
{
    public UserLoginCommandValidator()
    {
        RuleFor(p => p.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Phone number is required")
            .Length(11).WithMessage("Please enter a valid phone number")
            .Matches(@"[0-9]+").WithMessage("Please enter a valid phone number");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Password must not be empty");
    }
}