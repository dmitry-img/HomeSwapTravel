using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using MediatR;

namespace HomeSwapTravel.Application.Homes.Commands.DeleteHome;

public record DeleteHomeCommand(int HomeId) : IRequest<Unit>;

public class DeleteHomeCommandHandler : IRequestHandler<DeleteHomeCommand, Unit>
{
    private readonly IHomeRepository _homeRepository;

    public DeleteHomeCommandHandler(IHomeRepository homeRepository)
    {
        _homeRepository = homeRepository;
    }

    public async Task<Unit> Handle(DeleteHomeCommand request, CancellationToken cancellationToken)
    {
        var home = await _homeRepository.GetAsync(request.HomeId);
        
        if (home == null)
        {
            throw new NotFoundException(nameof(Home), request.HomeId);
        }

        await _homeRepository.DeleteAsync(home);
        
        return Unit.Value;
    }
}