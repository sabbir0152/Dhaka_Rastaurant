using FluentValidation;

namespace CodeCampRestora.Application.Extensions;

public static class FluentValidationExtension
{
    public static IRuleBuilderOptions<T, string> ValidatePassword<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        var specialCharacters = @"[\s!""#$%&'()*+,-./:;<=>?@[\]^_`{|}~]+";

        return ruleBuilder
            .NotEmpty().WithMessage("Password must not be empty")
            .MinimumLength(8).WithMessage("Password length must be at least 8 characters long")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one upper case letter")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lower case letter")
            .Matches(@"[0-9]+").WithMessage("Password must contain at least one number")
            .Matches(specialCharacters).WithMessage("Password must contain at least one special character");
    }
}