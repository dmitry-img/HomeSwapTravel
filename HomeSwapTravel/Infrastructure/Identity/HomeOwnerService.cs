using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Models;
using Application.Common.Interfaces.Persistence;

namespace HomeSwapTravel.Infrastructure.Identity;

public class HomeOwnerService : IHomeOwnerService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IHomeRepository _homeRepository;
    private readonly IHomeOwnerVisitedHomeRepository _homeOwnerVisitedHomeRepository;

    public HomeOwnerService(UserManager<ApplicationUser> userManager, IMapper mapper, IHomeRepository homeRepository, IHomeOwnerVisitedHomeRepository homeOwnerVisitedHomeRepository)
    {
        _userManager = userManager;
        _mapper = mapper;
        _homeRepository = homeRepository;
        _homeOwnerVisitedHomeRepository = homeOwnerVisitedHomeRepository;
    }

    public async Task<HomeOwner> GetHomeOwnerAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var homeVisited = await _homeOwnerVisitedHomeRepository.GetByHomeOwner(userId);

        return new HomeOwner()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailVerified = user.EmailConfirmed,
            PhoneVerified = user.PhoneNumberConfirmed,
            PhotoPath = user.PhotoPath,
            VisitedHomes = homeVisited.ToList(),
        };
    }

    public async Task<List<HomeOwner>> GetHomeOwnersAsync()
    {
        var users = await _userManager.GetUsersInRoleAsync("HomeOwner");
        return users.Select(user => new HomeOwner()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            EmailVerified = user.EmailConfirmed,
            PhoneVerified = user.PhoneNumberConfirmed,
            PhotoPath = user.PhotoPath
        }).ToList();
    }
}