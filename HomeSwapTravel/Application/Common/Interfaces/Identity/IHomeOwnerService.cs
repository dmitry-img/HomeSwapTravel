using Microsoft.Extensions.DependencyInjection.Models;

namespace HomeSwapTravel.Application.Common.Interfaces.Identity;

public interface IHomeOwnerService
{
    Task<HomeOwner> GetHomeOwnerAsync(string userId);
    Task<List<HomeOwner>> GetHomeOwnersAsync();
}