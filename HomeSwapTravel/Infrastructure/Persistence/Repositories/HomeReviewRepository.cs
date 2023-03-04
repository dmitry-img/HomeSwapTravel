using Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class HomeReviewRepository : GenericRepository<HomeReview>, IHomeReviewRepository
{
    private readonly ApplicationDbContext _dbContext;
    public HomeReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<HomeReview> GetByConditionWithDeatils(Func<HomeReview, bool> expression)
    {
        return _dbContext.HomeReviews.Include(hr => hr.Review).Where(expression).AsQueryable();
    }
}
