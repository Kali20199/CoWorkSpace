using System.ComponentModel.DataAnnotations;

namespace CoWorkSpace.Model
{
    #nullable disable
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}