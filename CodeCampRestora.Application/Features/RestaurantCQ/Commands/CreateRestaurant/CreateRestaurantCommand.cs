using CodeCampRestora.Application.Models;
using CodeCampRestora.Application.Common.Interfaces.MediatRs;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.CreateRestaurant;

public record CreateRestaurantCommand : ICommand<IResult>
{
    public string Name { get; set; } = default!;
    public string ImagePath { get; set; } = default!;
}
