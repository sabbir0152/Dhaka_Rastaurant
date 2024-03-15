using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeCampRestora.Application.Common.Interfaces.DbContexts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<T> DbSet<T>() where T: class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get;  }
}