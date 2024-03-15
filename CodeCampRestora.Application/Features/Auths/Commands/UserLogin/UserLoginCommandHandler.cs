using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.UserLogin;

public class UserLoginCommandCommandHandler : ICommandHandler<UserLoginCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public UserLoginCommandCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    public async Task<IResult> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var mobileUserLoginDto = request.Adapt<MobileUserLoginDto>();
        var result = await _identityService.AuthenticateMobileUserAsync(mobileUserLoginDto);

        return result;
    }
}

