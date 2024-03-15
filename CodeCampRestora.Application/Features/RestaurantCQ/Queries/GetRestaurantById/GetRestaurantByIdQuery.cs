using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Dtos;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Queries.GetRestaurantById;

public record GetRestaurantByIdQuery(Guid Id) : IQuery<IResult<RestaurantDto>>;     

