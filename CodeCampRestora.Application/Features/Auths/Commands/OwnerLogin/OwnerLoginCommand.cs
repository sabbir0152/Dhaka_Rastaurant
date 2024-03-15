
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public record OwnerLoginCommand(string Username, string Password) : ICommand<IResult>;