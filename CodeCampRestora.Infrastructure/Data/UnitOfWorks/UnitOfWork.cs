using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.Repositories;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace CodeCampRestora.Infrastructure.Data.UnitOfWorks;

[ScopedLifetime]
public class UnitOfWork : IUnitOfWork
{
    public IImageRepository Images { get; }
    public IOrderRepository Orders { get; }
    public IRestaurantRepository Restaurants { get; }
    public IBranchRepository Branches { get; }
    public IMenuItemRepository MenuItem { get; }
    public IReviewCommentRepository Comments { get; }
    public IMenuCategoryRepository MenuCategory { get; }
    public IReviewRepository Reviews { get; }

    private readonly IApplicationDbContext _appplicationDbContext;

    private IDbContextTransaction? _transaction = null;

    public UnitOfWork(
        IImageRepository images,
        IOrderRepository orders,
        IBranchRepository branches,
        IMenuItemRepository menuItem,
        IRestaurantRepository restaurants,
        IMenuCategoryRepository menuCategory,
        IReviewCommentRepository reviewComment,
        IReviewRepository review,
        IApplicationDbContext applicationDbContext)
    {
        _appplicationDbContext = applicationDbContext;
        Images = images;
        Orders = orders;
        Branches = branches;
        MenuItem = menuItem;
        Comments = reviewComment;
        Restaurants = restaurants;
        MenuCategory = menuCategory;
        Reviews = review;
    }

    public void CreateTransaction()
    {
        _transaction = _appplicationDbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
    }

    public async Task SaveChangesAsync()
    {
        await _appplicationDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appplicationDbContext.Dispose();
    }
}