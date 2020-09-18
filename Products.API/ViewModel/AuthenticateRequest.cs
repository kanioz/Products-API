using System.ComponentModel.DataAnnotations;

namespace Products.API.ViewModel
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
