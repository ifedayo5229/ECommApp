using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class Cart : BaseEntity
	{
		// Additional properties specific to carts
		// ...

		// Relationships
		public int UserId { get; set; } // Foreign key to User
		public User User { get; set; } // Navigation property to User
		public List<CartItem> Items { get; set; } // Collection navigation property to CartItem
	}
}
