using HomeSwapTravel.Domain.Common;
using HomeSwapTravel.Domain.Enums;

namespace HomeSwapTravel.Domain.Entities;

public class Review : BaseEntity
{
    public string ReviewerId { get; set; }
    public DateTime ReviewDate { get; set; }
    public HomeRating Rating { get; set; }
    public string? Content { get; set; }
    public IList<HomeReview> HomeReviews { get; private set; } = new List<HomeReview>();
}