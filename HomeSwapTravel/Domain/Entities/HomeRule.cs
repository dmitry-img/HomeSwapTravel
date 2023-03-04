namespace HomeSwapTravel.Domain.Entities;

public class HomeRule
{
    public int HomeId { get; set; }
    public int RuleId { get; set; }
    public Home? Home { get; set; }
    public Rule? Rule { get; set; }
}