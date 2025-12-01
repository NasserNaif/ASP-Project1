namespace Project1.Models.DTO
{
    public class RegionDto
    {
        public Guid? Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        // Accept Null
        public string? RegionImageUrl { get; set; }
    }
}
