using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Entities;

namespace CodeCampRestora.Application.Common.Interfaces.Repositories;

public interface IBranchRepository : IRepository<Branch, Guid>
{
    Task<IList<Branch>> GetBranchesByRestaurant(
    Restaurant restaurant,
    string includeProperties = "",
    int pageIndex = 1,
    int pageSize = 10);
}
