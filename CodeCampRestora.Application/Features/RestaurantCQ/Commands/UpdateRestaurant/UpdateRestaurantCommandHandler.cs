using Mapster;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;


namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler : ICommandHandler<UpdateRestaurantCommand, IResult>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRestaurantCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWork.Restaurants.GetByIdAsync(request.Id);
        if (restaurant is null) return Result.Failure(RestaurantErrors.NotFound);

        restaurant = request.Adapt(restaurant);
        await _unitOfWork.Restaurants.UpdateAsync(restaurant.Id, restaurant);

        return Result.Success();
    }
}
