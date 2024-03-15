using Mapster;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Features.RestaurantCQ.Commands.UpdateRestaurant;
using CodeCampRestora.Application.Features.Branches.Commands.UpdateBranch;
using CodeCampRestora.Domain.Entities.Branches;

namespace CodeCampRestora.Application;

public static class MapsterConfig
{
    public static void AddMapsterConfig()
    {
        TypeAdapterConfig<UpdateRestaurantCommand, Restaurant>
            .NewConfig()
            .Ignore(x => x.Id);

        TypeAdapterConfig<UpdateBranchCommand, Branch>
            .NewConfig()
            .Ignore(src => src.Id);
    }
     
}
