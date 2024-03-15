using Mapster;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler : ICommandHandler<GetRestaurantByIdQuery, IResult<RestaurantDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRestaurantByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IResult<RestaurantDto>> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWork.Restaurants.GetByIdAsync(request.Id);
        if (restaurant is null) return Result<RestaurantDto>.Failure(RestaurantErrors.NotFound);

        var restaurantDto = restaurant.Adapt<RestaurantDto>();
        return Result<RestaurantDto>.Success(restaurantDto);
    }
}
