using System.Collections.Generic;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface ICartRepository
    {
        void AddCart(Cart cart);
        void ClearCartByUserId(string userId);
        List<CartView> GetCartByUserId(string userId);
        Cart GetCartByUserIdAndProductId(string userId, int productId);
        void RemoveCart(Cart cartProduct);
    }
}