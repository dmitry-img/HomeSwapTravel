using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Models;

namespace Application.Common.Models;

public class HomeOwnerDto : IMapFrom<HomeOwner>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoPath { get; set; }
    public int ExchangesCount { get; set; }
    public IList<Language>? SpokenLanguages { get; set; }
}
