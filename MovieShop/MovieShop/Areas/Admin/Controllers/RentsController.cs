using MovieShop.Data.Interfaces;
using MovieShop.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.Areas.Admin.Controllers
{
    public class RentsController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public RentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Rents
        public ActionResult Index()
        {
            var model = _unitOfWork.Rent.GetRents();

            return View(model);
        }

        [HttpGet]
        public ActionResult Rents()
        {
            var rents = _unitOfWork.Rent.GetRents();

            var model = rents.Select(r => new ListRentsDTO
            {
                MovieTitle = r.Movie.Title,
                Genre = r.Movie.Genre.Name,
                UserName = r.User.UserName
            });

            return Json(new { data = model }, JsonRequestBehavior.AllowGet);
        }
    }
}