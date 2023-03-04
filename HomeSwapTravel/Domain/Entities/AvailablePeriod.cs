using Domain.ValueObjects;
using HomeSwapTravel.Domain.Common;
using HomeSwapTravel.Domain.Entities;

namespace Domain.Entities;
public class AvailablePeriod : BaseEntity
{
    public AvailablePeriod()
    {

    }

    public AvailablePeriod(DateTime from, DateTime to)
    {
        Period = new Period(from, to);
    }
    public Period? Period { get; set; }
    public IList<HomeAvailablePeriod>? HomeAvailablePeriods { get; set; } = new List<HomeAvailablePeriod>();
}
