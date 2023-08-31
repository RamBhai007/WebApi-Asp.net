using System.ComponentModel.DataAnnotations;

namespace praticeAPI.Models.DTO
{
    public class RegisterReq
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
