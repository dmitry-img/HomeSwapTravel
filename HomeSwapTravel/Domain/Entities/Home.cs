using HomeSwapTravel.Domain.Common;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Domain.ValueObjects;

namespace HomeSwapTravel.Domain.Entities;

public class Home : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? HomeOwnerId { get; set; }
    public HomeType HomeType  { get; set; }
    public ResidenceType ResidenceType { get; set; }
    public Address? Address { get; set; }
    public SurfaceArea? SurfaceArea { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public bool PetsLive { get; set; }
    public string? HomeDescription { get; set; }
    public string? NeighborhoodDescription { get; set; }
    public HomeRating Rating { get; set; } 
    public IList<HomeBedType> HomeBedTypes{ get; private set; } = new List<HomeBedType>();
    public IList<HomeAmenity>? HomeAmenities { get; private set; } = new List<HomeAmenity>();
    public IList<HomeRule>? HomeRules { get; private set; } = new List<HomeRule>();
    public IList<HomeAvailablePeriod>? HomeAvailablePeriods { get; private set; } = new List<HomeAvailablePeriod>();
    public IList<HomeReview>? HomeReviews { get; private set; } = new List<HomeReview>();
}