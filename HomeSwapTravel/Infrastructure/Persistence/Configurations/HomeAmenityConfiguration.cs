using HomeSwapTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;

public class HomeAmenityConfiguration : IEntityTypeConfiguration<HomeAmenity>
{
    public void Configure(EntityTypeBuilder<HomeAmenity> builder)
    {
        builder.HasKey(sc => new { sc.HomeId, sc.AmenityId });
        
        builder
            .HasOne<Home>(sc => sc.Home)
            .WithMany(s => s.HomeAmenities)
            .HasForeignKey(sc => sc.HomeId);


        builder
            .HasOne<Amenity>(sc => sc.Amenity)
            .WithMany(s => s.HomeAmenities)
            .HasForeignKey(sc => sc.AmenityId);
    }
}