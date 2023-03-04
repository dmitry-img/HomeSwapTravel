using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;

namespace HomeSwapTravel.Application.Common.Interfaces.Persistence;

public interface IRequestRepository : IGenericRepository<Request>
{
    Task ChangeStatusAsync(Request request, RequestStatus requestStatus);
    IEnumerable<Request> GetByHomeOwner(string homeOwnerId);
}

