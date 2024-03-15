namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IUnitOfWork
{
    IImageRepository Images { get; }
    IOrderRepository Orders { get; }
    IBranchRepository Branches { get; }
    IRestaurantRepository Restaurants { get; }
    IMenuItemRepository MenuItem { get; }
    IMenuCategoryRepository MenuCategory { get; }
    IReviewCommentRepository Comments { get; }
    IReviewRepository Reviews { get; }
    Task SaveChangesAsync();
}
