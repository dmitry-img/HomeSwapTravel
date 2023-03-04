using Domain.Entities;
using Domain.ValueObjects;

namespace HomeSwapTravel.Domain.Entities;

public class HomeAvailablePeriod
{
    public int HomeId { get; set; }
    public int AvailablePeriodId { get; set; }
    public AvailablePeriod? AvailablePeriod { get; set; }
    public Home? Home { get; set; }
}