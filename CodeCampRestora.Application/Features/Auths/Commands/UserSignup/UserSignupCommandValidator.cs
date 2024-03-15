using FluentValidation;
using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Extensions;
using CodeCampRestora.Application.Features.Auths.Commands.UserSignup;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public class UserSignupCommandValidator : ApplicationValidator<UserSignupCommand>
{
    public UserSignupCommandValidator()
    {
        RuleFor(p => p.FullName).NotEmpty().WithMessage("Full name is required");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Please enter a valid email address");

        RuleFor(p => p.Password).Cascade(CascadeMode.Stop).ValidatePassword();

        RuleFor(p => p.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Phone number is required")
            .Length(11).WithMessage("Please enter a valid phone number")
            .Matches(@"[0-9]+").WithMessage("Please enter a valid phone number");
    }
}