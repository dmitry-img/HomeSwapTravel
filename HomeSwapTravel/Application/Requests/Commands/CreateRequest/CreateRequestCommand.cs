using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using AutoMapper;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using MediatR;

namespace HomeSwapTravel.Application.Requests.Commands.CreateRequest;

public class CreateRequestCommand : IRequest<int>, IMapFrom<Request>
{
    public string? ReceiverId { get; set; }
    public DateTime RequestDate { get; set; }
    public int AvailablePeriodId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRequestCommand, Request>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.AvailablePeriod, opt => opt.Ignore())
            .ForMember(dest => dest.SenderId, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => RequestStatus.Pending));
    }
}

public class CreateRequestHandler : IRequestHandler<CreateRequestCommand, int>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public CreateRequestHandler(IRequestRepository requestRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _requestRepository = requestRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var requestCommand = _mapper.Map<Request>(request);

        requestCommand.SenderId = _currentUserService.UserId;

        requestCommand = await _requestRepository.AddAsync(requestCommand);
        
        return requestCommand.Id;
    }
}