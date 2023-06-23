using ECommApp.Api.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : AppBaseController
	{

		private readonly UserManager<ApplicationUser> userManager;
		private readonly UserManager<ApplicationUser> roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticationController(UserManager<ApplicationUser> userManager, UserManager<ApplicationUser> roleManager, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
		}


		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{

			var userExist = await userManager.FindByNameAsync(model.Username);
			if (userExist != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response
				{
					Status = "Error",
					Message = "User Already Exist",
				});

			}
			ApplicationUser user = new ApplicationUser()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username,
			};
			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response
				{
					Status = "Error",
					Message = "User Creation failed",
				});
			}
			return Ok(new Response
			{
				Status = "Success",
				Message = "User Created Successfully",
			});
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginModel model)
		{
			var user = await userManager.FindByNameAsync(model.UserName);
			if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
			{
              var userRoles = await userManager.GetRolesAsync(user);
				var authClaims = new List<Claim>
				{
				  new Claim(ClaimTypes.Name, user.UserName),
				  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				foreach (var userRole in userRoles) 
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}

				var authSigningInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
				var token = new JwtSecurityToken(
					issuer: _configuration["JWT:ValidIssuer"],
					audience: _configuration["JWT:ValidIssuer"],
					expires	: DateTime.Now.AddHours(5),
					claims : authClaims,
					signingCredentials	: new SigningCredentials(authSigningInKey,SecurityAlgorithms.HmacSha256)
					);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token)	
				});
			}

			return Unauthorized();
		}
 }  }
