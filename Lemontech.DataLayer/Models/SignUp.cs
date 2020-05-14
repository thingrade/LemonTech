namespace Lemontech.DataLayer.Models
{
    public class SignUpOptions
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class SignUpResult
    {
        public string Token { get; set; }
        public bool Succeeded { get; set; }
    }
}
