using System.Reflection;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Identity;
using HomeSwapTravel.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeSwapTravel.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) 
        : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public DbSet<Amenity> Amenities => Set<Amenity>();
    public DbSet<BedType> BedTypes => Set<BedType>();
    public DbSet<Home> Homes => Set<Home>(); 
    public DbSet<HomeAmenity> HomeAmenities => Set<HomeAmenity>();
    public DbSet<AvailablePeriod> AvailablePeriods => Set<AvailablePeriod>();
    public DbSet<HomeAvailablePeriod> HomeAvailablePeriods => Set<HomeAvailablePeriod>();
    public DbSet<HomeBedType> HomeBedTypes => Set<HomeBedType>();
    public DbSet<HomeRule> HomeRules => Set<HomeRule>();
    public DbSet<Request> Requests => Set<Request>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<HomeReview> HomeReviews => Set<HomeReview>();
    public DbSet<Rule> Rules => Set<Rule>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<HomeOwnerVisitedHome> HomeOwnerVisitedHomes => Set<HomeOwnerVisitedHome>();
}
