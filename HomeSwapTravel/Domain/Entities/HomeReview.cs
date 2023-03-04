namespace HomeSwapTravel.Domain.Entities;

public class HomeReview
{
    public int HomeId { get; set; }
    public int ReviewId { get; set; }
    public Home? Home { get; set; }
    public Review? Review { get; set; }
}