using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class CartItem : BaseEntity
	{
		public int Quantity { get; set; }
		// Additional properties specific to cart items
		// ...

		// Relationships
		public int CartId { get; set; } // Foreign key to Cart
		public CartItem Cart { get; set; } // Navigation property to Cart
		public int ProductId { get; set; } // Foreign key to Product
		public Product Product { get; set; } // Navigation property to Product
	}
}
