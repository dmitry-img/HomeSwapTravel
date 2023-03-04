using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using AutoMapper;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Application.Homes.Commands.CreateHome;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Domain.ValueObjects;
using MediatR;
using Domain.Entities;
using Domain.ValueObjects;
using HomeSwapTravel.Application.Common.Mappings;

namespace HomeSwapTravel.Application.Homes.Commands.UpdateHome;

public class UpdateHomeCommand : IRequest<Unit>, IMapFrom<Home>
{
    public int HomeId { get; set; }
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
        profile.CreateMap<UpdateHomeCommand, Home>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.Title, opt => opt.Ignore())
           .ForMember(dest => dest.HomeOwnerId, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
           .ForMember(dest => dest.Created, opt => opt.Ignore())
           .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
           .ForMember(dest => dest.LastModified, opt => opt.Ignore())
           .ForMember(dest => dest.Rating, opt => opt.Ignore())
           .ForMember(dest => dest.HomeReviews, opt => opt.Ignore())
           .ForMember(dest => dest.HomeBedTypes, opt => opt.MapFrom(src => src.BedTypeCount != null ? src.BedTypeCount.Select(bt => new HomeBedType { BedTypeId = bt.BedTypeId, Count = bt.Count }).ToList() : new List<HomeBedType>()))
           .ForMember(dest => dest.HomeAmenities, opt => opt.MapFrom(src => src.AmenityIds != null ? src.AmenityIds.Select(a => new HomeAmenity { AmenityId = a }).ToList() : new List<HomeAmenity>()))
           .ForMember(dest => dest.HomeRules, opt => opt.MapFrom(src => src.RuleIds != null ? src.RuleIds.Select(r => new HomeRule { RuleId = r }).ToList() : new List<HomeRule>()))
           .ForMember(dest => dest.HomeAvailablePeriods, opt => opt.MapFrom(src => src.AvailablePeriods != null ? src.AvailablePeriods.Select(ap => new HomeAvailablePeriod { AvailablePeriod = new AvailablePeriod(ap.From, ap.To) }).ToList() : new List<HomeAvailablePeriod>()));
    }
}

public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommand, Unit>
{
    private readonly IHomeRepository _homeRepository;
    private readonly IMapper _mapper;

    public UpdateHomeCommandHandler(IHomeRepository homeRepository, IMapper mapper)
    {
        _homeRepository = homeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateHomeCommand request, CancellationToken cancellationToken)
    {
        var home = await _homeRepository.GetWithDetailsAsync(request.HomeId);

        if (home == null)
            throw new NotFoundException(nameof(Home), request.HomeId);
        
        home.HomeAmenities?.Clear();
        home.HomeRules?.Clear();
        home.HomeAvailablePeriods?.Clear();
        home.HomeBedTypes?.Clear();

        _mapper.Map(request, home);

        await _homeRepository.UpdateAsync(home);

        return Unit.Value;
    }
}