using MovieShop.Data.Interfaces;
using MovieShop.ViewModels.Admin.Dashboard;
using System.Web.Mvc;

namespace MovieShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var model = new DashboardIndexViewModel
            {
                MovieCount = _unitOfWork.Movie.GetCount(),
                UserCount = _unitOfWork.User.GetCount(),
                RentCount = _unitOfWork.Rent.GetCount()
            };

            return View(model);
        }

    }
}