using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;

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
