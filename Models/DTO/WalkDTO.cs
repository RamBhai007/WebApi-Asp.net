namespace praticeAPI.Models.DTO
{
    public class WalkDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKM { get; set; }
        public String? WalkImageURL { get; set; }
        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }
        public RegionDTO Region { get; set; }
        public DifficutlyDTO Difficutly { get; set; }

    }
}
