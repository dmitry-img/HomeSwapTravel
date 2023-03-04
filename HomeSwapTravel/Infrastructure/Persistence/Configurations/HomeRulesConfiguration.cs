using HomeSwapTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;

public class HomeRulesConfiguration : IEntityTypeConfiguration<HomeRule>
{
    public void Configure(EntityTypeBuilder<HomeRule> builder)
    {
        builder.HasKey(sc => new { sc.HomeId, sc.RuleId });
        
        builder
            .HasOne<Home>(sc => sc.Home)
            .WithMany(s => s.HomeRules)
            .HasForeignKey(sc => sc.HomeId);


        builder
            .HasOne<Rule>(sc => sc.Rule)
            .WithMany(s => s.HomeRules)
            .HasForeignKey(sc => sc.RuleId);
    }
}