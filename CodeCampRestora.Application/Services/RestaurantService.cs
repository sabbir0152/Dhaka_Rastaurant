using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.Services;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Application.Services;

[ScopedLifetime]
public class RestaurantService : IRestaurantService
{
    private readonly IUnitOfWork _unitOfWork;

    public RestaurantService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult<Guid>> CreateRestaurantAsync(Restaurant restaurant)
    {
        await _unitOfWork.Restaurants.AddAsync(restaurant);
        await _unitOfWork.SaveChangesAsync();
        return Result<Guid>.Success(restaurant.Id);
    }
}
