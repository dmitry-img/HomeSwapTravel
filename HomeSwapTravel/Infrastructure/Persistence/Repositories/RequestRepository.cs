using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using HomeSwapTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;
public class RequestRepository : GenericRepository<Request>, IRequestRepository
{
    private readonly ApplicationDbContext _dbContext;
    public RequestRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ChangeStatusAsync(Request request, RequestStatus requestStatus)
    {
        request.Status = requestStatus;
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<Request> GetReceivedByHomeOwner(string homeOwnerId)
    {
        return _dbContext.Requests.Include(r => r.AvailablePeriod).Where(r => r.ReceiverId == homeOwnerId);
    }

    public IEnumerable<Request> GetSentByHomeOwner(string homeOwnerId)
    {
        return _dbContext.Requests.Include(r => r.AvailablePeriod).Where(r => r.SenderId == homeOwnerId);
    }

    public async Task<Request?> GetWithDeatilsAsync(int id)
    {
        return await _dbContext.Requests
            .Include(r => r.AvailablePeriod)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}

