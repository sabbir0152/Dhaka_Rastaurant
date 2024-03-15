using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CodeCampRestora.Application.Common.Interfaces.Services;

namespace CodeCampRestora.Infrastructure.Data.Interceptors;

public class AuditableEntitiesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUserService;

    public AuditableEntitiesInterceptor(
        IDateTimeService dateTimeService,
        ICurrentUserService currentUserService
    )
    {
        _dateTimeService = dateTimeService;
        _currentUserService = currentUserService;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var dbContext = eventData.Context;
        if (dbContext is not null)
        {
            var entries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(e => e.CreatedBy).CurrentValue = _currentUserService.UserId;
                    entry.Property(e => e.Created).CurrentValue = _dateTimeService.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(e => e.LastModifiedBy).CurrentValue = _currentUserService.UserId;
                    entry.Property(e => e.LastModified).CurrentValue = _dateTimeService.Now;
                }
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}