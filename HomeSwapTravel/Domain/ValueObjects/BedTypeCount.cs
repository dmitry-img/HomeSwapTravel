using HomeSwapTravel.Domain.Common;

namespace Domain.ValueObjects;
public class BedTypeCount : ValueObject
{
    public int BedTypeId { get; set; }
    public int Count { get; set; }

    public BedTypeCount()
    {
        
    }

    public BedTypeCount(int bedTypeId, int count)
    {
        BedTypeId = bedTypeId;
        Count = count;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return BedTypeId;
        yield return Count;
    }
}

