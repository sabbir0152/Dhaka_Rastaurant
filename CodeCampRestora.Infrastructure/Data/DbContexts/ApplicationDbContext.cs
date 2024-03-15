using Microsoft.EntityFrameworkCore;
using CodeCampRestora.Domain.Entities;
using CodeCampRestora.Domain.Identity;
using CodeCampRestora.Domain.Entities.Orders;
using CodeCampRestora.Application.Attributes;
using CodeCampRestora.Infrastructure.Entities;
using CodeCampRestora.Domain.Entities.Branches;
using CodeCampRestora.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CodeCampRestora.Application.Common.Interfaces.DbContexts;

namespace CodeCampRestora.Infrastructure.Data.DbContexts;

[ScopedLifetime]
public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Staff)
            .WithOne(t => t.ApplicationUser)
            .HasForeignKey<Staff>(b => b.ApplicationUserId)
            .IsRequired(false);

        SeedRoles(builder);
    }

    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<ApplicationRole>().HasData
        (
            new ApplicationRole { Id = Guid.NewGuid(), Name = "User", ConcurrencyStamp = "1", NormalizedName = "USER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Owner", ConcurrencyStamp = "2", NormalizedName = "OWNER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "MANAGER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "Waiter", ConcurrencyStamp = "4", NormalizedName = "WAITER" },
            new ApplicationRole { Id = Guid.NewGuid(), Name = "KitchenStuff", ConcurrencyStamp = "5", NormalizedName = "KITCHENSTUFF" }
        );
    }

    public DbSet<T> DbSet<T>() where T: class => Set<T>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Staff> Staffs => Set<Staff>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();
    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();
    public DbSet<Order> Orders {  get; set; }
    public DbSet<OrderItem> OrderItems {  get; set; }
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<ReviewComment> ReviewComments => Set<ReviewComment>();
}
