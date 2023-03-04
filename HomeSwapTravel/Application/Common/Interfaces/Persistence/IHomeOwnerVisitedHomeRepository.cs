using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IHomeOwnerVisitedHomeRepository : IGenericRepository<HomeOwnerVisitedHome>
{
    Task<IReadOnlyList<HomeOwnerVisitedHome>> GetByHomeOwner(string homeOwnerId);
}
