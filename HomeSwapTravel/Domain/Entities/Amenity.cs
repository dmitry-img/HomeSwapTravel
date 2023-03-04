using HomeSwapTravel.Domain.Common;

namespace HomeSwapTravel.Domain.Entities;

public class Amenity : BaseEntity
{
    public string? Name { get; set; }
    public IList<HomeAmenity>? HomeAmenities { get; private set; } = new List<HomeAmenity>();
}