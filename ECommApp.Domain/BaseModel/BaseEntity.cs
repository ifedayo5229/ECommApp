using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Domain.BaseModel
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool Deleted { get; set; }
		public string EditedBy { get; set; }	

	}
}
