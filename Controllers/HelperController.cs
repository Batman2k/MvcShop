using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RapidMountain.Core;
using RapidMountain.Core.Dtos;
using RapidMountain.Core.Models;
using RapidMountain.Persistence;

namespace RapidMountain.Controllers
{
    public class HelperController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HelperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PartialViewResult RenderCategories()
        {
            var viewModel = _unitOfWork.Categories.GetCategories();

            if (!viewModel.Any())
                viewModel = new List<Category>
                {
                    new Category
                    {
                        Name = "Empty",
                        SubCategories =
                            new List<SubCategory>
                            {
                                new SubCategory {Amount = 1, Name = "Empty"}
                            }
                    }
                };

            return PartialView("RenderCategories", viewModel);
        }
        
        public PartialViewResult RenderProducts(IEnumerable<Product> products)
        {
            return PartialView("RenderProducts", products);
        }

        public FileResult RenderPictureUri(int id)
        {
            var context = new ApplicationDbContext();

            var picture = context.Pictures.First(p => p.Id == id).Img;

            if (picture == null)
                return null;
            
            return File(picture, "image/jpg");
        }

        public ActionResult RenderCart()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new List<CartDto>();

            if (userId != null)
            viewModel = _unitOfWork.Carts.GetCartDtosByUserId(userId);
            
            
            
            return PartialView("RenderCart", viewModel);
        }
    }
}