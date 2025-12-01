namespace Project1.Models.Domain;

public class Walk
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }
    public string DifficultyId { get; set; }
    public string RegionId { get; set; }
    
    // Navigation Properties
    public Difficulty Difficulty { get; set; }
    public Region Region { get; set; }
}