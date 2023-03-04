using HomeSwapTravel.Domain.Entities;

namespace HomeSwapTravel.Application.Common.Interfaces.Persistence;

public interface IHomeRepository : IGenericRepository<Home>
{
    IQueryable<Home> GetAllAsQueryable();
    Task<Home?> GetWithDetailsAsync(int id);
    Task<Home?> GetByHomeOwnerAsync(string homeOwnerId);
    Task RecalculateRatingAsync(int homeId);
}

