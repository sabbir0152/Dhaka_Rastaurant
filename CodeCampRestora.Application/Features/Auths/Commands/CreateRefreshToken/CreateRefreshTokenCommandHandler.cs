using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.CreateRefreshToken;

public class CreateRefreshTokenCommandHandler : ICommandHandler<CreateRefreshTokenCommand, IResult>
{
    private readonly IIdentityService _identityService;

    public CreateRefreshTokenCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IResult> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.RefreshTokenAsync(
            request.AccessToken,
            request.RefreshToken,
            cancellationToken);

        return result;
    }
}