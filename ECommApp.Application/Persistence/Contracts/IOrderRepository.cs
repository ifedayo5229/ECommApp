using ECommApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
		IEnumerable<Order> GetOrdersByUserId(int userId);
		IEnumerable<Order> GetOrdersByVendorId(int vendorId);
		Order GetOrderById(int orderId);
		void PlaceOrder(Order order);
		void UpdateOrderStatus(int orderId, string status);
		decimal CalculateOrderTotal(int orderId);
		// Additional order-specific contracts...
	}


}
