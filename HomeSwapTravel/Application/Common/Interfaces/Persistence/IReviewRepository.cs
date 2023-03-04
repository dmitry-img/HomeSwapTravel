using HomeSwapTravel.Domain.Entities;
using System.Linq.Expressions;

namespace HomeSwapTravel.Application.Common.Interfaces.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    Task UpdateContentAsync(Review review, string Content);
}

