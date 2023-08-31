using System.ComponentModel.DataAnnotations.Schema;

namespace praticeAPI.Models.DTO
{
    public class imageUpload
    {

        public IFormFile file { get; set; }
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
        public string fileExtension { get; set; }
        public long fileSize { get; set; }
        public string filePath { get; set; }
    }
}
