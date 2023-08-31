using System.ComponentModel.DataAnnotations;

namespace praticeAPI.Models.DTO
{
    public class UpdateWalkPost
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0, 50)]
        public double LengthInKM { get; set; }
        public String? WalkImageURL { get; set; }
        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }
    }
}
