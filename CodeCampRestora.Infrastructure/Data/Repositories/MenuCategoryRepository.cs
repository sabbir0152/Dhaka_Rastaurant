using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Helpers.Pagination;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Models;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class MenuCategoryRepository : Repository<MenuCategory, Guid>, IMenuCategoryRepository
{
    private readonly DbSet<MenuCategory> _menuCategory;
    private readonly ApplicationDbContext _context;
    public MenuCategoryRepository(IApplicationDbContext applicationDbContext, ApplicationDbContext context) 
    : base((DbContext)applicationDbContext)
    {
        _menuCategory = context.Set<MenuCategory>();
        _context = context;
    }

    public async Task<List<MenuCategory>> GetAllByIdAsync(Guid Id)
    {
        var Entities = _menuCategory.Where(e => e.RestaurantId == Id).ToList();
        return Entities;
    }

    public async Task<List<MenuCategory>> GetAllHomeMenuCategoryAsync()
    {
        return await _menuCategory.ToListAsync();
    }

    public async Task<PagedList<MenuCategory>> GetPaginatedByIdAsync(Guid Id, int pageNumber, int pageSize)
    {
        var Entities = _menuCategory.Where(e => e.RestaurantId == Id);

        var PagedList = await PagedList<MenuCategory>.ToPagedListAsync(
            Entities, 
            pageNumber, 
            pageSize,
            query => query.OrderBy(MenuCategory => MenuCategory.DisplayOrder)
        );
        
        return PagedList;
    }

    public async Task<IResult> UpdateMenuCategoryAsync(List<MenuCategory> newMenuCategories)
    {
        foreach (var newMenuCategory in newMenuCategories)
        {
            var existingEntity = await _menuCategory.FindAsync(newMenuCategory.Id);

            if (existingEntity == null)
            {
                return Result.Failure(Error.NotFound($"Menu category with Id {newMenuCategory.Id} not found!"));
            }

            existingEntity.DisplayOrder =  newMenuCategory.DisplayOrder;
            _menuCategory.Entry(existingEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Result.Success();
    }
}