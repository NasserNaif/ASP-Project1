using Project1.Models.Domain;

namespace Project1.Models.DTO
{
    public class WalksDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        // Navigation Properties
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

    }
}
