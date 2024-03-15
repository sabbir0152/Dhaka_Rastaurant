using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.UserSignup;

public record UserSignupCommand(
    string FullName,
    string Email,
    string Password,
    string Phone
) : ICommand<IResult>;
