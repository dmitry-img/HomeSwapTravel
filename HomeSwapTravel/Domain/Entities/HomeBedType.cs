using HomeSwapTravel.Domain.Common;

namespace HomeSwapTravel.Domain.Entities;

public class HomeBedType : BaseEntity
{
    public int HomeId { get; set; }
    public int BedTypeId { get; set; }
    public int Count { get; set; }
    public Home? Home { get; set; }
    public BedType? BedType { get; set; }
}