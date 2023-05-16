using ECommApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
	public interface ICartRepository : IGenericRepository<Cart>
	{
		Cart GetCartByUserId(int userId);
		void AddProductToCart(int cartId, int productId, int quantity);
		void RemoveProductFromCart(int cartId, int productId);
		void UpdateCartItemQuantity(int cartItemId, int quantity);
		decimal CalculateCartTotal(int cartId);
		// Additional cart-specific contracts...
	}
}
