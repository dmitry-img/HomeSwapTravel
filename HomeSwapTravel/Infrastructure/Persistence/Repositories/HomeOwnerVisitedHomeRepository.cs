using Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class HomeOwnerVisitedHomeRepository : GenericRepository<HomeOwnerVisitedHome>, IHomeOwnerVisitedHomeRepository
{
    private readonly ApplicationDbContext _dbContext;
    public HomeOwnerVisitedHomeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<HomeOwnerVisitedHome>> GetByHomeOwner(string homeOwnerId)
    {
        return await _dbContext.HomeOwnerVisitedHomes.Include(h => h.Home)
             .Where(h => h.HomeOwnerId == homeOwnerId).ToListAsync();
    }
}

