using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.UserLogin;

public record UserLoginCommand(string Phone, string Password) : ICommand<IResult>;
