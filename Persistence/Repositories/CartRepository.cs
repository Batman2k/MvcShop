using System.Collections.Generic;
using System.Linq;
using RapidMountain.Core.Models;
using RapidMountain.Core.Repositories;

namespace RapidMountain.Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IApplicationDbContext _context;

        public CartRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartView> GetCartByUserId(string userId)
        {
            return _context.Carts
                .Where(c => c.UserId == userId)
                .Select(c => new CartView
                {
                    Amount = c.Amount,
                    ProductId = c.ProductId,
                    Name = c.Product.Name,
                    PictureId = c.Product.Pictures.FirstOrDefault().Id,
                    Price = c.Product.Price
                })
                .ToList();
        }

        public Cart GetCartByUserIdAndProductId(string userId, int productId)
        {
            return _context.Carts.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

        }

        public void RemoveCart(Cart cartProduct)
        {
            _context.Carts.Remove(cartProduct);
        }

        public void AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
        }

        public void ClearCartByUserId(string userId)
        {
            var carts = _context.Carts.Where(c => c.UserId == userId).ToList();

            foreach (var cart in carts)
                _context.Carts.Remove(cart);
        }
    }
}