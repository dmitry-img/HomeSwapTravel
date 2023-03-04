using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;
public class AvailablePeriodConfiguration : IEntityTypeConfiguration<AvailablePeriod>
{
    public void Configure(EntityTypeBuilder<AvailablePeriod> builder)
    {
        builder.OwnsOne(p => p.Period);
    }
}
