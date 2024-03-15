using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Infrastructure.Entities;


namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class BranchRepository : Repository<Branch, Guid>, IBranchRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Branch> _branchDbSet;
    public BranchRepository(IApplicationDbContext applicationDbContext)
        : base((DbContext)applicationDbContext)
    {
        _dbContext = (DbContext)applicationDbContext;
        _branchDbSet = _dbContext.Set<Branch>();
    }

    public async Task<IList<Branch>> GetBranchesByRestaurant(
    Restaurant restaurant,
    string includeProperties = "",
    int pageIndex = 1,
    int pageSize = 10)
    {
        IQueryable<Branch> query = _branchDbSet;


        if (restaurant != null)
        {
            query = query.Where(branch => branch.RestaurantId == restaurant.Id);
        }

        foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);


        var branchList = await result.ToListAsync();
        return branchList;
    }

}
