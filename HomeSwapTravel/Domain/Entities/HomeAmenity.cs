namespace HomeSwapTravel.Domain.Entities;

public class HomeAmenity
{
    public int HomeId { get; set; }
    public int AmenityId { get; set; }
    public Home? Home { get; set; }
    public Amenity? Amenity { get; set; }
}