using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeSwapTravel.Application.Requests.Commands.UpdateRequestState;

public record UpdateRequestStateCommand(int RequestId, RequestStatus RequestStatus) : IRequest<Unit>;

class UpdateRequestStateCommandHandle : IRequestHandler<UpdateRequestStateCommand, Unit>
{
    private readonly IRequestRepository _requestRepository;

    public UpdateRequestStateCommandHandle(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<Unit> Handle(UpdateRequestStateCommand request, CancellationToken cancellationToken)
    {
        var requestEntity = await _requestRepository.GetAsync(request.RequestId);

        if (requestEntity is null)
        {
            throw new NotFoundException(nameof(Request), request.RequestId);
        }

        await _requestRepository.ChangeStatusAsync(requestEntity, request.RequestStatus);
        
        return Unit.Value;
    }
}