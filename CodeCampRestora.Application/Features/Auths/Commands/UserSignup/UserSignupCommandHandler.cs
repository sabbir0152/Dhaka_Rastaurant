using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.Auths.Commands.UserSignup;

public class UserSignupCommandHandler : ICommandHandler<UserSignupCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public UserSignupCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public Task<IResult> Handle(UserSignupCommand request, CancellationToken cancellationToken)
    {
        var registerMobileUserDto = request.Adapt<RegisterMobileUserDTO>();
        var result = _identityService.RegisterMobileUserAsync(registerMobileUserDto);

        return result;
    }
}
