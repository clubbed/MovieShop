using MovieShop.Data.Interfaces;
using MovieShop.DTOs;
using MovieShop.Models;
using MovieShop.ViewModels;
using MovieShop.ViewModels.Admin.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MovieShop.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Admin/Dashboard
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