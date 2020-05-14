using System;
using System.ComponentModel.DataAnnotations;

namespace Lemontech.DataLayer.Models
{
    public class Credentials
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }

    public class LoginResponseModel
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
        public bool LoginSuccess { get; set; } = true;
        public string Message { get; set; }
    }

}
