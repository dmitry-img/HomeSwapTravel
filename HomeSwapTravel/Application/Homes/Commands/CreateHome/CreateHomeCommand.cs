using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Domain.ValueObjects;
using MediatR;
using HomeSwapTravel.Application.Common.Interfaces.Identity;

namespace HomeSwapTravel.Application.Homes.Commands.CreateHome;

public record CreateHomeCommand : IRequest<int>, IMapFrom<Home>
{
    public HomeType HomeType  { get; set; }
    public ResidenceType ResidenceType { get; set; }
    public Address? Address { get; set; }
    public SurfaceArea? SurfaceArea { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public bool PetsLive { get; set; }
    public string? HomeDescription { get; set; }
    public string? NeighborhoodDescription { get; set; }
    public List<int>? AmenityIds { get; set; }
    public List<int>? RuleIds { get; set; }
    public List<Period>? AvailablePeriods { get; set; }
    public List<BedTypeCount>? BedTypeCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHomeCommand, Home>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.Title, opt => opt.Ignore())
           .ForMember(dest => dest.HomeOwnerId, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
           .ForMember(dest => dest.Created, opt => opt.Ignore())
           .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
           .ForMember(dest => dest.LastModified, opt => opt.Ignore())
           .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new HomeRating()))
           .ForMember(dest => dest.HomeReviews, opt => opt.Ignore())
           .ForMember(dest => dest.HomeBedTypes, opt => opt.MapFrom(src => src.BedTypeCount != null ? src.BedTypeCount.Select(bt => new HomeBedType { BedTypeId = bt.BedTypeId, Count = bt.Count }).ToList() : new List<HomeBedType>()))
           .ForMember(dest => dest.HomeAmenities, opt => opt.MapFrom(src => src.AmenityIds != null ? src.AmenityIds.Select(a => new HomeAmenity { AmenityId = a }).ToList() : new List<HomeAmenity>()))
           .ForMember(dest => dest.HomeRules, opt => opt.MapFrom(src => src.RuleIds != null ? src.RuleIds.Select(r => new HomeRule { RuleId = r }).ToList() : new List<HomeRule>()))
           .ForMember(dest => dest.HomeAvailablePeriods, opt => opt.MapFrom(src => src.AvailablePeriods != null ? src.AvailablePeriods.Select(ap => new HomeAvailablePeriod { AvailablePeriod = new AvailablePeriod(ap.From, ap.To)}).ToList() : new List<HomeAvailablePeriod>()));
    }
}

public class CreateHomeCommandHandler : IRequestHandler<CreateHomeCommand, int>
{
    private readonly IHomeRepository _homeRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IHomeOwnerService _homeOwnerService;

    public CreateHomeCommandHandler(IHomeRepository homeRepository, IMapper mapper, ICurrentUserService currentUserService, IHomeOwnerService homeOwnerService)
    {
        _homeRepository = homeRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _homeOwnerService = homeOwnerService;
    }

    public async Task<int> Handle(CreateHomeCommand request, CancellationToken cancellationToken)
    {
        var home = _mapper.Map<Home>(request);

        home.HomeOwnerId = _currentUserService.UserId;

        var homeOwner = await _homeOwnerService
            .GetHomeOwnerAsync(_currentUserService.UserId!);

        home.Title = $"{homeOwner.FirstName}'s home";

        await _homeRepository.AddAsync(home);

        return home.Id;
    }
}