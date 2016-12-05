using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RapidMountain.Core;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Extensions;
using RapidMountain.Core.Models;
using RapidMountain.Core.ViewModels;
using RapidMountain.Persistence;

namespace RapidMountain.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public ActionResult Index()
        //{
        //    return View(new 
        //        HomeViewModel
        //    {
        //        Title = "Main Page",
        //        SearchTerm = "aa"
        //    });
        //}

        public ActionResult Index(string searchTerm = null)
        {


            
            var viewModel = new HomeViewModel
            {
                Title = "Main Page",
                SearchTerm = searchTerm
            };

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var products = _unitOfWork.Products.SearchProducts(searchTerm);
                //TODO ADD CHECK
                viewModel.Title = "Results for " + searchTerm;
                viewModel.Products = _unitOfWork.Products.SearchProducts(searchTerm);
            }

            return View(viewModel);
        }

        public ActionResult SubCategory(string subCategory, string category)
        {
            var viewModel = new HomeViewModel
            {
                Title = subCategory,
                Products = _unitOfWork.Products.GetAllVisibleProductBySubCategory(category,subCategory)
            };

            if (viewModel.Products.FirstOrDefault() == null)
                return HttpNotFound();

            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var context = new ApplicationDbContext();

            context.Products.Add(new Product
            {
                AmountInStock = 3,
                Category = "test",
                SubCategory = "test",
                Name = "vas",
                IsVisible = true
            });

            //var client = new WebClient();

            //var img = client.DownloadData("http://inetimg.se/img/452x339/6608155_1.jpg");


            //var product = new Product {Name = "aaa" ,SubCategory = "vaaa",Category = "edrd",Pictures = new List<Picture> {new Picture {Img = img} } };

            //context.Products.Add(product);
            //context.SaveChanges();




            return View();
        }
    }
}