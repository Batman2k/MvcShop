using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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
                CartViews = _unitOfWork.Carts.GetCartDtosByUserId(User.Identity.GetUserId())
            };

            return View(viewMode);
        }

        //TODO Make Api instead?
        public ActionResult AddToCart(int productId)
        {
            //TODO improve query
            var cartViews = _unitOfWork.Carts.GetCartDtosByUserId(User.Identity.GetUserId());
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
            //TODO clean up
            var custInfo = _unitOfWork.CustomerInfos.GetCustomerInfoByUserId(User.Identity.GetUserId());

            if (custInfo == null)
            {
                var info = new CustomerInfo {UserId = User.Identity.GetUserId()};
                _unitOfWork.CustomerInfos.Add(info);
                _unitOfWork.Finish();
            }
            
            var viewModel = Mapper.Map<CheckoutViewModel>(custInfo);


            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Checkout(CheckoutViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var orderProducts = new List<OrderProduct>();
            var orderAddress = Mapper.Map<OrderAddress>(viewModel);
            var cartDtos = _unitOfWork.Carts.GetCartDtosByUserId(User.Identity.GetUserId());
            var products = _unitOfWork.Products.GetProductsByIds(cartDtos.Select(cd => cd.ProductId).ToList());
            var custInfo = _unitOfWork.CustomerInfos.GetCustomerInfoByUserId(User.Identity.GetUserId());
            
            custInfo.Update(viewModel);
          
            foreach (var cartDto in cartDtos)
            {
                orderProducts.Add(new OrderProduct
                {
                    Amount = cartDto.Amount,
                    Price = cartDto.Price,
                    ProductId = cartDto.ProductId
                });
                products.First(p => p.Id == cartDto.ProductId).AmountInStock -= cartDto.Amount;
            }
            
            var order = new Order
            {
                DatePlaced = DateTime.Now,
                IsPaid = true,
                OrderAddresses = new List<OrderAddress> {orderAddress},
                OrderProducts = orderProducts,
                UserId = User.Identity.GetUserId(),
                ShippingCost = viewModel.ShippingCost,
                TrackingNumber = "",
                PaymentMethod = viewModel.PaymentMethod,
                OrderStatus = "Unsent",
                
            };

            _unitOfWork.Orders.Add(order);
            _unitOfWork.Carts.ClearCartByUserId(User.Identity.GetUserId());
            _unitOfWork.Finish();

            return RedirectToAction("Details", "Order", new {id = order.Id});
        }
    }

    public class CheckoutViewModel
    {
        //  public int Total { get; set; }
        
            [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string AddressOne { get; set; }

        [StringLength(150)]
        public string AddressTwo { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Province { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public decimal ShippingCost { get; set; }

        public string PaymentMethod { get; set; }
    }
}