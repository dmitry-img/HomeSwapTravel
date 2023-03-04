using HomeSwapTravel.Domain.Common;
using HomeSwapTravel.Domain.Enums;

namespace HomeSwapTravel.Domain.ValueObjects;

public class SurfaceArea : ValueObject
{
    public double Value { get; set; }
    public MetricSystem MetricSystem { get; set; }

    public SurfaceArea() { }
    
    public SurfaceArea(double value, MetricSystem metricSystem)
    {
        Value = value;
        MetricSystem = metricSystem;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return MetricSystem;
    }
}