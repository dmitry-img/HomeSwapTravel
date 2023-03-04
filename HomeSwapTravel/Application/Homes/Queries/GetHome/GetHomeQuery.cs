using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using AutoMapper;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using MediatR;
using Domain.ValueObjects;
using Application.Reviews;
using Application.Common.Models;

namespace HomeSwapTravel.Application.Homes.Queries.GetHome;

public record GetHomeQuery(int HomeId) : IRequest<HomeDto>;

public class GetHomeQueryHandler : IRequestHandler<GetHomeQuery, HomeDto>
{
    private readonly IHomeRepository _homeRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IHomeOwnerService _homeOwnerService;

    public GetHomeQueryHandler(IHomeRepository homeRepository, IMapper mapper, ICurrentUserService currentUserService, IHomeOwnerService homeOwnerService)
    {
        _homeRepository = homeRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _homeOwnerService = homeOwnerService;
    }

    public async Task<HomeDto> Handle(GetHomeQuery request, CancellationToken cancellationToken)
    {
        var home = await _homeRepository.GetWithDetailsAsync(request.HomeId);

        if (home is null)
        {
            throw new NotFoundException(nameof(Home), request.HomeId);
        }
        
        var homeDto = _mapper.Map<HomeDto>(home);
        
        var homeOwner = await _homeOwnerService.GetHomeOwnerAsync(_currentUserService.UserId);

        homeDto.HomeOwner = _mapper.Map<HomeOwnerDto>(homeOwner);
        
        bool? didCurrentUserVisitHome = homeOwner.VisitedHomes
            .Where(h => h.HomeId == request.HomeId) != null;

        homeDto.Visited = didCurrentUserVisitHome != null && didCurrentUserVisitHome == true;

        homeDto.AvailablePeriods = new List<Period>();
        home.HomeAvailablePeriods
            .Select(h => h.AvailablePeriod.Period).ToList()
            .ForEach(p => homeDto.AvailablePeriods.Add(p));

        homeDto.Reviews = new List<ReviewDto>();
        home.HomeReviews
            .Select(h => h.Review).ToList()
            .ForEach(p => homeDto.Reviews.Add(_mapper.Map<ReviewDto>(p)));

        return homeDto;
    }
}