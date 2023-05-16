using ECommApp.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain
{
	public class Vendor :BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ContactEmail { get; set; }
		// Additional properties specific to vendors
		// ...
	}
}
