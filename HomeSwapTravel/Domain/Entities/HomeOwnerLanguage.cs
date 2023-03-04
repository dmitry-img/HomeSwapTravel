namespace HomeSwapTravel.Domain.Entities;

public class HomeOwnerLanguage
{
    public string? HomeOwnerId { get; set; }
    public int LanguageId { get; set; }
    public Language? Language { get; set; }
}