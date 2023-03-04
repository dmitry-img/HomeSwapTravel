using HomeSwapTravel.Domain.Common;

namespace HomeSwapTravel.Domain.Entities;

public class Rule : BaseEntity
{
    public string? Name { get; set; }
    public IList<HomeRule>? HomeRules { get; private set; } = new List<HomeRule>();
}