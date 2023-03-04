using HomeSwapTravel.Domain.Common;

namespace Domain.ValueObjects;
public class Period : ValueObject
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public Period()
    {

    }

    public Period(DateTime from, DateTime to)
    {
        From = from;
        To = to;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return From;
        yield return To;
    }
}
