using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;


namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class RestaurantRepository : Repository<Restaurant, Guid>, IRestaurantRepository
{
    public RestaurantRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
    }
}
