using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class RegisterViewModel : PageModel
    {
        public bool EmailExists { get; set; }

        public RegisterViewModel()
        {
            EmailExists = false;
        }
    }
}
