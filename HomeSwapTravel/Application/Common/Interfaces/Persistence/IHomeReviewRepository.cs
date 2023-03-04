using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using HomeSwapTravel.Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IHomeReviewRepository : IGenericRepository<HomeReview>
{
    IQueryable<HomeReview> GetByConditionWithDeatils(Func<HomeReview, bool> expression);
}
