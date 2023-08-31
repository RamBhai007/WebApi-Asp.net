using System.ComponentModel.DataAnnotations;

namespace praticeAPI.Models.DTO
{
    public class AddRegionPost
    {
        [Required]
        [MinLength(2,ErrorMessage ="code should be minimum of to character")]
        [MaxLength(5,ErrorMessage ="code should be minimum of to character")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ImageURL { get; set; }
    }
}
