using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class LoginViewModel : PageModel
    {
        public bool IncorrectPassword { get; set; }

        public LoginViewModel()
        {
            IncorrectPassword = false;
        }
    }
}
