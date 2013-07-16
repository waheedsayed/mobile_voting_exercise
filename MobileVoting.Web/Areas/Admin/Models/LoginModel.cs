using System.ComponentModel.DataAnnotations;

namespace MobileVoting.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required, MinLength(6), MaxLength(20)]
        public string Password { get; set; }
    }
}