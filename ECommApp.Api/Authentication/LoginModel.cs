using System.ComponentModel.DataAnnotations;

namespace ECommApp.Api.Authentication
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Username is Requird")]
		public string UserName { get; set;}

		[Required(ErrorMessage = "Password is Requird")]
		public string Password { get; set;}
	}
}
