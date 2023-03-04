using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using MediatR;
using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using System.Runtime.InteropServices;

namespace HomeSwapTravel.Application.Requests.Commands.DeleteRequest;

public record DeleteRequestCommand(int RequestId) : IRequest<Unit>;

public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, Unit>
{
    private readonly IRequestRepository _requestRepository;
    private readonly ICurrentUserService _currentUserService;

    public DeleteRequestCommandHandler(IRequestRepository requestRepository, ICurrentUserService currentUserService)
    {
        _requestRepository = requestRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
    {
        var requestEntity = await _requestRepository.GetAsync(request.RequestId);
        
        if (requestEntity == null)
            throw new NotFoundException(nameof(Home), request.RequestId);

        if (requestEntity.SenderId != _currentUserService.UserId)
            throw new ForbiddenAccessException();

        await _requestRepository.DeleteAsync(requestEntity);
        
        return Unit.Value;
    }
}