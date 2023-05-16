using ECommApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
	public interface IVendorRepository : IGenericRepository<Vendor>
	{
		Vendor GetByName(string name);
		IEnumerable<Vendor> GetByCategory(string category);
		IEnumerable<Vendor> GetByLocation(string location);
		IEnumerable<Vendor> SearchVendors(string keyword);
		void UpdateVendorRating(int vendorId, double rating);
		IEnumerable<Product> GetVendorProducts(int vendorId);
		// Additional vendor-specific contracts...

	}
}

