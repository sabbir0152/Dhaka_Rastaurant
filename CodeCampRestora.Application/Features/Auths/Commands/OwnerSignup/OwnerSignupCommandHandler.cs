using Mapster;
using CodeCampRestora.Application.DTOs;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.Auths.Commands.RestaurantOwner.Signup;

public class OwnerSignupCommandHandler : ICommandHandler<OwnerSignupCommand, IResult>
{
    private readonly IIdentityService _identityService;
    private readonly IRestaurantService _restaurantService;

    public OwnerSignupCommandHandler(
        IIdentityService identityService,
        IRestaurantService restaurantService)
    {
        _identityService = identityService;
        _restaurantService = restaurantService;
    }

    public async Task<IResult> Handle(OwnerSignupCommand request, CancellationToken cancellationToken)
    {
        var restaurantEO = Restaurant.CreateDefaultRestaurant(request.RestaurantName);
        var restaurantResult = await _restaurantService.CreateRestaurantAsync(restaurantEO);
        if(!restaurantResult.IsSuccess) return restaurantResult;

        var registerUserDTO = request.Adapt<RegisterUserDTO>();
        var result = await _identityService.RegisterRestaurantOwnerAsync(registerUserDTO, restaurantResult.Data);

        return result;
    }
}