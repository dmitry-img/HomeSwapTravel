using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Models;

namespace HomeSwapTravel.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoPath { get; set; }
    public int ExchangesCount { get; set; }
    public IList<Language>? SpokenLanguages { get; set; }
}
