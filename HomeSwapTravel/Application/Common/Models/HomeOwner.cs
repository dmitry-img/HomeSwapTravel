using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;

namespace Microsoft.Extensions.DependencyInjection.Models;

public class HomeOwner
{
    public string? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoPath { get; set; }
    public int ExchangesCount { get; set; }
    public bool EmailVerified { get; set; }
    public bool PhoneVerified { get; set; }
    public IList<HomeOwnerVisitedHome>? VisitedHomes { get; set; }
}