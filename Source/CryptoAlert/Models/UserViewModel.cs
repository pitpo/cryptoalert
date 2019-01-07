using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
	public class UserViewModel : PageModel
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserAuthenticationService _userAuthenticationService = new UserAuthenticationServiceFactory().Create();

		public User User { get; set; }

		public UserViewModel()
		{
			_httpContextAccessor = new HttpContextAccessor();
			var authCookie = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
			User = _userAuthenticationService.GetUserFromToken(new Token(authCookie));
		}
	}
}