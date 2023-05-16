using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class Order : BaseEntity
	{
		public decimal TotalAmount { get; set; }
		// Additional properties specific to orders
		// ...

		// Relationships
		public int UserId { get; set; } // Foreign key to User
		public User User { get; set; } // Navigation property to User
	}
}
