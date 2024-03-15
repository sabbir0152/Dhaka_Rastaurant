using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

public record OwnerSignupCommand(
    string FullName,
    string? RestaurantName,
    string Email,
    string Password
) : ICommand<IResult>;