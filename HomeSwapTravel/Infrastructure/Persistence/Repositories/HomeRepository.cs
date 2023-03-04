using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Persistence.Repositories;
public class HomeRepository : GenericRepository<Home>, IHomeRepository
{
    private readonly ApplicationDbContext _dbContext;
    public HomeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Home> GetAllAsQueryable()
    {
        return _dbContext.Homes.AsQueryable();
    }

    public async Task<Home?> GetByHomeOwnerAsync(string homeOwnerId)
    {
        var home = await _dbContext.Homes.FirstOrDefaultAsync(h => h.HomeOwnerId == homeOwnerId);
        return home;
    }

    public async Task<Home?> GetWithDetailsAsync(int id)
    {
        return await _dbContext.Homes
            .Include(h => h.HomeBedTypes)
            .Include(h => h.HomeAmenities)
            .Include(h => h.HomeRules)
            .Include(h => h.HomeAvailablePeriods)
                .ThenInclude(h => h.AvailablePeriod)
            .Include(h => h.HomeReviews)
                .ThenInclude(h => h.Review)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
}

