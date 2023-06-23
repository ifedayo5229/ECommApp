using System.ComponentModel.DataAnnotations;

namespace ECommApp.Api.Authentication
{
	public class RegisterModel
	{
		[Required( ErrorMessage = "Username is Requird")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Email is Requird")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is Requird")]
		public string Password { get; set; }


		

	}
}
