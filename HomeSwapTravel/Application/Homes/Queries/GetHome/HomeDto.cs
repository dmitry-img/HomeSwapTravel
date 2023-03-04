using Application.Common.Models;
using Application.Reviews;
using AutoMapper;
using Domain.ValueObjects;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Domain.ValueObjects;

namespace HomeSwapTravel.Application.Homes.Queries.GetHome;

public class HomeDto : IMapFrom<Home>
{
    public string? Title { get; set; }
    public string? HomeOwnerId { get; set; }
    public HomeOwnerDto? HomeOwner { get; set; }
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
    public IList<BedTypeCount>? BedTypeCounts { get; set; } 
    public IList<int>? AmenitiyIds { get; set; } 
    public IList<int>? RuleIds { get; set; } 
    public IList<Period>? AvailablePeriods { get;  set; } 
    public IList<ReviewDto>? Reviews { get;  set; } 
    public bool Visited { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Home, HomeDto>()
            .ForMember(dest => dest.HomeOwner, opt => opt.Ignore())
            .ForMember(dest => dest.Visited, opt => opt.Ignore())
            .ForMember(dest => dest.BedTypeCounts, opt => opt.MapFrom(src => src.HomeBedTypes
                .Select(hbt => new BedTypeCount(hbt.BedTypeId, hbt.Count))))
            .ForMember(dest => dest.AmenitiyIds, opt => opt.MapFrom(src => src.HomeAmenities
                .Select(ha => ha.AmenityId)))
            .ForMember(dest => dest.RuleIds, opt => opt.MapFrom(src => src.HomeRules
                .Select(hr => hr.RuleId)))
            .ForMember(dest => dest.AvailablePeriods, opt => opt.MapFrom(src => src.HomeAvailablePeriods
               .Select(hr => hr.AvailablePeriod.Period)))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.HomeReviews != null ? src.HomeReviews.Select(hr => hr.Review) : new List<Review>()));
    }
}