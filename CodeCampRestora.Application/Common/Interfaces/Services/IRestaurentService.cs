using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Common.Interfaces.Services;

public interface IRestaurentService
{
    Task<IResult> Create(RestaurantDto restaurantDto);
    Task<IResult> GetAll();
    Task<IResult> GetById(Guid id);
    Task<IResult> Update(Guid id, RestaurantDto restaurantDto);
    Task<IResult> DeleteById(Guid id);
}
