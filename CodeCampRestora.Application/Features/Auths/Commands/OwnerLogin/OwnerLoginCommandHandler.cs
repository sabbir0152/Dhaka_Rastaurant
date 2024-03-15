using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.OwnerLogin;

public class OwnerLoginCommandCommandHandler : ICommandHandler<OwnerLoginCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public OwnerLoginCommandCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IResult> Handle(OwnerLoginCommand request, CancellationToken cancellationToken)
    {
        var loginDTO = request.Adapt<LoginDTO>();
        var result = await _identityService.AuthenticatRestaurantOwnerAsync(loginDTO);

        return result;
    }
}