using System.ComponentModel.DataAnnotations;

namespace praticeAPI.Models.DTO
{
    public class LoginReq
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}
