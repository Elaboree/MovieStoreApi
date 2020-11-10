using System.ComponentModel.DataAnnotations;

namespace MovieStoreApi.Service.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
