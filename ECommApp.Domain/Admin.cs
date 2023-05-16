using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class Admin : BaseEntity
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		// Additional properties specific to admins
		// ...

	}
}
