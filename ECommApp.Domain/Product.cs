using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		// Additional properties specific to products
		// ...

		// Relationships
		public int VendorId { get; set; } // Foreign key to Vendor
		public Vendor Vendor { get; set; } // Navigation property to Vendor
	}
}
