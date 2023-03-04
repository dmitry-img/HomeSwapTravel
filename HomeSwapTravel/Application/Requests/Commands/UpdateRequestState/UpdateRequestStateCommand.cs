using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Persistence;

namespace HomeSwapTravel.Application.Requests.Commands.UpdateRequestState;

public record UpdateRequestStateCommand(int RequestId, RequestStatus RequestStatus) : IRequest<Unit>;

class UpdateRequestStateCommandHandle : IRequestHandler<UpdateRequestStateCommand, Unit>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IHomeOwnerVisitedHomeRepository _visitedHomeRepository;
    private readonly IHomeRepository _homeRepository;

    public UpdateRequestStateCommandHandle(IRequestRepository requestRepository, IHomeOwnerVisitedHomeRepository visitedHomeRepository, IHomeRepository homeRepository)
    {
        _requestRepository = requestRepository;
        _visitedHomeRepository = visitedHomeRepository;
        _homeRepository = homeRepository;
    }

    public async Task<Unit> Handle(UpdateRequestStateCommand request, CancellationToken cancellationToken)
    {
        var requestEntity = await _requestRepository.GetWithDeatilsAsync(request.RequestId);

        if (requestEntity is null)
            throw new NotFoundException(nameof(Request), request.RequestId);
        
        if(request.RequestStatus == RequestStatus.Completed)
        {
            if (requestEntity.AvailablePeriod.Period.To < DateTime.Now)
                throw new BadRequestException("Home swap period is not over yet!");

            var senderHome = await _homeRepository.GetByHomeOwnerAsync(requestEntity.SenderId);
            var receiverHome = await _homeRepository.GetByHomeOwnerAsync(requestEntity.ReceiverId);


            await _visitedHomeRepository.AddAsync(
                new HomeOwnerVisitedHome { HomeOwnerId = requestEntity.ReceiverId, Home = senderHome });

            await _visitedHomeRepository.AddAsync(
                new HomeOwnerVisitedHome { HomeOwnerId = requestEntity.SenderId, Home = receiverHome });


        }

        await _requestRepository.ChangeStatusAsync(requestEntity, request.RequestStatus);
        
        return Unit.Value;
    }
}