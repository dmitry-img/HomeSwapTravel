using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;
using Application.Requests.Queries;

namespace HomeSwapTravel.Application.Requests.Queries.GetRequests;

public record GetReceivedRequestsQuery : IRequest<List<RequestDto>>;

public class GetReceivedRequestsQueryHandler : IRequestHandler<GetReceivedRequestsQuery, List<RequestDto>>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IRequestRepository _requestRepository;
    private readonly IHomeRepository _homeRepository;
    private readonly IMapper _mapper;
    private readonly IHomeOwnerService _homeOwnerService;

    public GetReceivedRequestsQueryHandler(ICurrentUserService currentUserService, IRequestRepository requestRepository, IHomeRepository homeRepository, IMapper mapper, IHomeOwnerService homeOwnerService)
    {
        _currentUserService = currentUserService;
        _requestRepository = requestRepository;
        _homeRepository = homeRepository;
        _mapper = mapper;
        _homeOwnerService = homeOwnerService;
    }

    public async Task<List<RequestDto>> Handle(GetReceivedRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = _requestRepository.GetReceivedByHomeOwner(_currentUserService.UserId);
        var requestDtos = _mapper.Map<List<RequestDto>>(requests);
        

        //TODO fix the code
        //requestDtos.ForEach(async requestDto => 
        //{
        //    var home = await _homeRepository.GetByHomeOwnerAsync(requestDto.SenderId);
        //    requestDto.HomeId = home.Id;
        //    requestDto.Home = _mapper.Map<HomeBriefDto>(home);
        //});
        
        return requestDtos;
    }
}