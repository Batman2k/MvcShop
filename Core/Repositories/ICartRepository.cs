using System.Collections.Generic;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Models;

namespace RapidMountain.Core.Repositories
{
    public interface ICartRepository
    {
        void AddCart(Cart cart);
        void ClearCartByUserId(string userId);
        List<Cart> GetCartByUserId(string userId);
        List<CartDto> GetCartDtosByUserId(string userId);
        Cart GetCartByUserIdAndProductId(string userId, int productId);
        void RemoveCart(Cart cartProduct);
    }
}