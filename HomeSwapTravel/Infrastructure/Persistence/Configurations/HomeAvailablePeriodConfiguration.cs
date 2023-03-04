using Domain.Entities;
using HomeSwapTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;

public class HomeAvailablePeriodConfiguration : IEntityTypeConfiguration<HomeAvailablePeriod>
{
    public void Configure(EntityTypeBuilder<HomeAvailablePeriod> builder)
    {
        builder.HasKey(sc => new { sc.HomeId, sc.AvailablePeriodId });

        builder
            .HasOne<Home>(sc => sc.Home)
            .WithMany(s => s.HomeAvailablePeriods)
            .HasForeignKey(sc => sc.HomeId);


        builder
            .HasOne<AvailablePeriod>(sc => sc.AvailablePeriod)
            .WithMany(s => s.HomeAvailablePeriods)
            .HasForeignKey(sc => sc.AvailablePeriodId);
    }
}