namespace Project1.Models.Domain;

public class Region
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }
    
    // Accept Null
    public string? RegionImageUrl { get; set; }
}