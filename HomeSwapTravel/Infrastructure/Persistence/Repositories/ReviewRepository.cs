using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using Azure.Core;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task UpdateContentAsync(Review review, string content)
        {
            review.Content = content;
            await _dbContext.SaveChangesAsync();
        }
    }
}
