using FluentValidation;
using CodeCampRestora.Application.Common;
using CodeCampRestora.Application.Extensions;
using CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public class OwnerSignupCommandValidator : ApplicationValidator<OwnerSignupCommand>
{
    public OwnerSignupCommandValidator()
    {
        RuleFor(p => p.FullName).NotEmpty().WithMessage("Full name is required");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email address is required")
            .EmailAddress().WithMessage("Please provide a valid email address");

        RuleFor(p => p.Password).Cascade(CascadeMode.Stop).ValidatePassword();
    }
}