using HomeSwapTravel.Domain.Common;

namespace HomeSwapTravel.Domain.Entities;

public class HomeOwnerVisitedHome : BaseEntity
{
    public string? HomeOwnerId { get; set; }
    public int HomeId { get; set; }
    public Home? Home { get; set; }
}