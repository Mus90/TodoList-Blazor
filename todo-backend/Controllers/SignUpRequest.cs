using System.ComponentModel.DataAnnotations;

namespace todo_backend.Controllers
{
    public class SignUpRequest
    {
        public string  UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}