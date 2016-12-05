using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RapidMountain.Core;

namespace RapidMountain.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Details(int id)
        {
            return View(_unitOfWork.Orders.GetOrderByUserIdAndId(User.Identity.GetUserId(), id));
        }

        public ActionResult Orders()
        {
            return View(_unitOfWork.Orders.GetOrderDtosByUserId(User.Identity.GetUserId()));
        }
    }
}