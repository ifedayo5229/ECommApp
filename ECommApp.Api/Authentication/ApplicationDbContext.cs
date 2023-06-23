using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommApp.Api.Authentication
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
		{
		
		}


		public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
		{
			public ApplicationDbContext CreateDbContext(string[] args)
			{
				var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
				optionsBuilder.UseSqlServer("Data Source=SDSD-IFE;Initial Catalog=ECommDB;Integrated Security=True");

				return new ApplicationDbContext(optionsBuilder.Options);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}
