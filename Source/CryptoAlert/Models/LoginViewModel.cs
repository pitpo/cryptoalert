using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
