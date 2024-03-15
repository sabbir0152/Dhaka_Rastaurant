using CodeCampRestora.Application.Common.Interfaces.MediatRs;
using CodeCampRestora.Application.Models;
using System.Windows.Input;

namespace CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;

public record UpdateRestaurantCommand : ICommand<IResult>
{
    public UpdateRestaurantCommand(Guid id)
    {        
        Id = id;
    }
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public Guid ImageId { get; set; } = default!;
}
