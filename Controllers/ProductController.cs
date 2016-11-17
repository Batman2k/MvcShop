using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RapidMountain.Core;
using RapidMountain.Core.Extensions;
using RapidMountain.Core.Models;
using RapidMountain.Core.ViewModels;

namespace RapidMountain.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //TODO move to homecontroller? 
        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = _unitOfWork.Products.GetProductById(id);

            if (product == null)
                return HttpNotFound();
            
            var viewModel = Mapper.Map<ProductViewModel>(product);
            var averageScore = 0.0;

            if (product.Reviews.Any())
                averageScore = product.Reviews.Select(r => r.Stars).Average();

            viewModel.AverageScore = Convert.ToInt32(averageScore);
            
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Details(int id, string name, string email, string text, int starvote)
        {
            var review = new Review
            {
                ProductId = id,
                MadeBy = name,
                Stars = starvote,
                Text = text,
                Written = DateTime.Now
            };

            _unitOfWork.Reviews.AddReview(review);
            _unitOfWork.Finish();
            
            return RedirectToAction("Details", id);
        }


        public ActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Title = "Create"
            };

            return View("ProductForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel, IEnumerable<HttpPostedFileBase> files)
        {
            var product = Mapper.Map<Product>(viewModel);

            foreach (var file in files)
            {
                if (file?.ContentLength > 0)
                    product.Pictures.Add(new Picture
                    {
                        Img = Image.FromStream(file.InputStream, true, true).ToByteArray()
                    });
            }

            _unitOfWork.Products.AddProduct(product);
            _unitOfWork.Finish();

            return RedirectToAction("Details", new {id = product.Id});
        }
        
        //public ActionResult AddToCart()
        //{
        //    return View();
        //}
    }
}