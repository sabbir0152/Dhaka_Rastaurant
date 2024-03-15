using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Models;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuItemRepository : Repository<MenuItem,Guid>, IMenuItemRepository
{
    private readonly DbSet<MenuItem> _menuItem;
    private readonly ApplicationDbContext _context;
    public MenuItemRepository(IApplicationDbContext applicationDbContext,
    ApplicationDbContext context)
        : base((DbContext) applicationDbContext)
    {
        _menuItem = context.Set<MenuItem>();
        _context = context;
    }

    public async Task<List<MenuItem>> GetAllByIdAsync(Guid Id)
    {
        var Entities = _menuItem.Where(e => e.BranchId == Id).ToList();
        return Entities;
    }

    public async Task<PagedList<MenuItem>> GetPaginatedByIdAsync(
        Guid Id, int pageNumber, int pageSize
    )
    {
        var Entities = _menuItem.Where(e => e.BranchId == Id);

        var PagedList = await PagedList<MenuItem>.ToPagedListAsync(
            Entities, 
            pageNumber, 
            pageSize,
            query => query.OrderBy(MenuItem => MenuItem.DisplayOrder)
        );
        
        return PagedList;
    }

    public async Task<IResult> UpdateMenuItemsAsync(List<MenuItem> newMenuItems)
    {

        foreach (var newMenuItem in newMenuItems)
        {
            var existingEntity = await _menuItem.FindAsync(newMenuItem.Id);

            if (existingEntity == null)
            {
                return Result.Failure(Error.NotFound($"Menu item with Id {newMenuItem.Id} not found!"));
            }

            existingEntity.DisplayOrder =  newMenuItem.DisplayOrder;
            _menuItem.Entry(existingEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Result.Success();
    }
}