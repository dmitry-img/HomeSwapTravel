using HomeSwapTravel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeSwapTravel.Infrastructure.Persistence.Configurations;

public class HomeReviewConfiguration : IEntityTypeConfiguration<HomeReview>
{
    public void Configure(EntityTypeBuilder<HomeReview> builder)
    {
        builder.HasKey(sc => new { sc.HomeId, sc.ReviewId });
        
        builder
            .HasOne<Home>(sc => sc.Home)
            .WithMany(s => s.HomeReviews)
            .HasForeignKey(sc => sc.HomeId);


        builder
            .HasOne<Review>(sc => sc.Review)
            .WithMany(s => s.HomeReviews)
            .HasForeignKey(sc => sc.ReviewId);
    }
}