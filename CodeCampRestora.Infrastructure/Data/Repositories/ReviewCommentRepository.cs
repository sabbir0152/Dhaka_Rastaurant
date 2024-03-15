using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;
using CodeCampRestora.Application.Common.Interfaces.Repositories;

namespace CodeCampRestora.Infrastructure.Data.Repositories;

[ScopedLifetime]
public class ReviewCommentRepository : Repository<ReviewComment, Guid>, IReviewCommentRepository
{
    public ReviewCommentRepository(IApplicationDbContext applicationDbContext) 
        : base((DbContext)applicationDbContext)
    {
        
    }
}
