using ECommApp.Api.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ECommApp.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var configuration = services.GetRequiredService<IConfiguration>();
					var connectionString = configuration.GetConnectionString("ConnStr");
					var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
						.UseSqlServer(connectionString)
						.Options;

					var dbContext = new ApplicationDbContext(dbContextOptions);
					// Apply any pending migrations
					dbContext.Database.Migrate();

					// ... additional initialization or migration logic if needed

					// Start the application
					host.Run();
				}
				catch (Exception ex)
				{
					// Handle any errors that occur during application startup
					Console.WriteLine("An error occurred during application startup.");
					Console.WriteLine(ex.Message);
				}
			}
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
					config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
					config.AddEnvironmentVariables();
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Program>();
					webBuilder.UseEnvironment("Development"); // Set the hosting environment to "Development"
				});

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Call Entity Framework and provide the connection string
			var serviceProvider = services.BuildServiceProvider();
			var configuration = serviceProvider.GetService<IConfiguration>();
			var connectionString = configuration.GetConnectionString("ConnStr");

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			// Identity
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			// Adding authentication
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidAudience = configuration["JWT:ValidAudience"],
					ValidIssuer = configuration["JWT:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
				};
			});

			services.AddSwaggerGen();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// Add production-specific configuration
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
			});

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
