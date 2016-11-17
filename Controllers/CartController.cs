using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RapidMountain.Core;
using RapidMountain.Core.Models;
using RapidMountain.Core.ViewModels;

namespace RapidMountain.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ActionResult Cart()
        {
            var viewMode = new CartViewModel
            {
                Title = "Cart",
                CartViews = _unitOfWork.Carts.GetCartByUserId(User.Identity.GetUserId())
            };

            return View(viewMode);
        }

        //TODO Make Api instead?
        public ActionResult AddToCart(int productId)
        {
            //TODO improve query
            var cartViews = _unitOfWork.Carts.GetCartByUserId(User.Identity.GetUserId());
            var cartProduct = cartViews.FirstOrDefault(cv => cv.ProductId == productId);

            if (cartProduct == null)
            {
                _unitOfWork.Carts.AddCart(new Cart
                {
                    Amount = 1,
                    ProductId = productId,
                    UserId = User.Identity.GetUserId()
                });
            }
            else
            {
                var cart = _unitOfWork.Carts.GetCartByUserIdAndProductId(User.Identity.GetUserId(), productId);
                cart.Amount++;
            }
            _unitOfWork.Finish();

            return RedirectToAction("Cart");
        }

        public ActionResult UpdateCartAmount(int productId, int amount)
        {
            var cartProduct = _unitOfWork.Carts.GetCartByUserIdAndProductId(User.Identity.GetUserId(), productId);

            if (cartProduct == null)
                _unitOfWork.Carts.AddCart(new Cart
                {
                    Amount = amount,
                    ProductId = productId,
                    UserId = User.Identity.GetUserId()
                });
            else if (amount > 0)
                cartProduct.Amount = amount;

            else
                _unitOfWork.Carts.RemoveCart(cartProduct);
            
            _unitOfWork.Finish();

            return RedirectToAction("Cart");
        }

        public ActionResult ClearCart()
        {
            _unitOfWork.Carts.ClearCartByUserId(User.Identity.GetUserId());
            _unitOfWork.Finish();

            return RedirectToAction("Cart");
        }

        public ActionResult Checkout()
        {
            
            var viewModel = new CheckoutViewModel
            {
                Total = 1
            };


            return View(viewModel);
        }

    }

    public class CheckoutViewModel
    {
        public int Total { get; set; }
    }
}