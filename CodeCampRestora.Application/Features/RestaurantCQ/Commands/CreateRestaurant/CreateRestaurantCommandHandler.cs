using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, IResult>
{
    private readonly IRestaurantService _restaurantService;

    public CreateRestaurantCommandHandler(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public async Task<IResult> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurantModel = request.Adapt<Restaurant>();

        await _restaurantService.CreateRestaurantAsync(restaurantModel);
        return Result.Success();
    }
}
