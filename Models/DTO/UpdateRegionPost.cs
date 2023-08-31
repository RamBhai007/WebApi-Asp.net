using System.ComponentModel.DataAnnotations;

namespace praticeAPI.Models.DTO
{
    public class UpdateRegionPost
    {
        [Required]
        [MinLength(2,ErrorMessage ="min Length is 2")]
        [MaxLength(5, ErrorMessage = "max Length is 5")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ImageURL { get; set; }
    }
}
