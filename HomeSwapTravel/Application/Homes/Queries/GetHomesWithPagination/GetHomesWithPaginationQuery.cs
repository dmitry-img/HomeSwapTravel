using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Application.Common.Models;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Domain.ValueObjects;
using MediatR;

namespace HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;

public class GetHomesWithPaginationQuery : IRequest<PaginatedList<HomeBriefDto>>
{
    public Address? Address { get; set; }
    public List<HomeType>? HomeTypes { get; set; }
    public List<ResidenceType>? ResidenceTypes { get; set; }
    public List<Amenity>? Amenities { get; set; }
    public List<Rule>? Rules { get; set; }
    public int? Bedrooms { get; set; }
    public int? Bathrooms { get; set; }
    public SortingOption SortingOption { get; set; } = SortingOption.ByRating;
    public DateTime Created { get; set; }

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

class GetHomesWithPaginationQueryHandler : IRequestHandler<GetHomesWithPaginationQuery, PaginatedList<HomeBriefDto>>
{
    private readonly IHomeRepository _homeRepository;
    private readonly IMapper _mapper;

    public GetHomesWithPaginationQueryHandler(IHomeRepository homeRepository, IMapper mapper)
    {
        _homeRepository = homeRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<HomeBriefDto>> Handle(GetHomesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var homes = _homeRepository.GetAllAsQueryable();

        if (request.Address != null)
        {
            if (request.Address.City != null)
                homes = homes.Where(h => h.Address.City == request.Address.City);
            else
                homes = homes.Where(h => h.Address.Country == request.Address.Country);
        }

        if (request.HomeTypes != null)
        {
            homes = homes.Where(h => request.HomeTypes.Contains(h.HomeType));
        }

        if (request.ResidenceTypes != null)
        {
            homes = homes.Where(h => request.ResidenceTypes.Contains(h.ResidenceType));
        }

        if (request.Amenities != null)
        {
            homes = homes.Where(h => 
                request.Amenities.Select(a => a.Id)
                    .Intersect(h.HomeAmenities.Select(h => h.AmenityId)) != null);
        }

        if (request.Rules != null)
        {
            homes = homes.Where(h =>
                request.Rules.Select(r => r.Id)
                    .Intersect(h.HomeRules.Select(r => r.RuleId)) != null);
        }

        if (request.Bedrooms != null)
        {
            homes = homes.Where(h => h.Bedrooms == request.Bedrooms);
        }

        if (request.Bathrooms != null)
        {
            homes = homes.Where(h => h.Bathrooms == request.Bathrooms);
        }

        switch (request.SortingOption)
        {
            case SortingOption.ByRating:
                homes = homes.OrderByDescending(h => h.Rating);
                break;
            case SortingOption.ByNewHomes:
                homes = homes.OrderByDescending(h => h.Created);
                break;
        }

        return await homes.ProjectTo<HomeBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}