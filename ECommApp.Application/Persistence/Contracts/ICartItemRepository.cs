using ECommApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommApp.Application.Persistence.Contracts
{
	public interface ICartItemRepository : IGenericRepository<CartItem>
	{
		IEnumerable<CartItem> GetCartItemsByCartId(int cartId);
		CartItem GetCartItemByCartAndProductId(int cartId, int productId);
		void UpdateCartItemQuantity(int cartItemId, int quantity);
		void RemoveCartItem(int cartItemId);
		// Additional cart item-specific contracts...
	}
}
