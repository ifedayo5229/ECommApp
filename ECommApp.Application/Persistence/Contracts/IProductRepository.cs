using ECommApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		IEnumerable<Product> GetProductsByVendorId(int vendorId);
		IEnumerable<Product> GetProductsByCategory(string category);
		Product GetProductById(int productId);
		void AddProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(int productId);
		// Additional product-specific contracts...

	}
}
