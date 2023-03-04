using HomeSwapTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;

public class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.Property(p => p.HomeType).IsRequired();
        builder.Property(p => p.ResidenceType).IsRequired();
        builder.Property(p => p.Bedrooms).IsRequired();
        builder.Property(p => p.Bathrooms).IsRequired();
        builder.Property(p => p.PetsLive).IsRequired();

        builder.OwnsOne(p => p.Address);
        builder.OwnsOne(p => p.SurfaceArea);
    }
}