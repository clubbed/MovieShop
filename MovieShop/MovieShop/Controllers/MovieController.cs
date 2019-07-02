using Microsoft.AspNet.Identity;
using MovieShop.Data.Interfaces;
using MovieShop.Models;
using MovieShop.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MovieShop.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(int? page, string search)
        {
            var movies = _unitOfWork.Movie.GetAll();

            if (search != null)
            {
                movies = _unitOfWork.Movie.SearchMoviesByTitle(search);
            }

            var model = movies.Select(movie => new IndexMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                ImagePath = movie.ImagePath,
                Description = movie.Description,
                GenreName = movie.Genre.Name,
                ReleasedDate = movie.ReleaseDate.ToShortDateString()
            });

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movie.GetMovieById(id);

            var rent = _unitOfWork.Rent.GetRentsOfMovie(movie.Id);

            var model = new DetailsMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImagePath = movie.ImagePath,
                UserId = User.Identity.GetUserId(),
                Rent = rent.Select(r => new RentViewModel
                {
                    UserId = r.UserId,
                    MovieId = r.MovieId
                })
            };

            return View(model);
        }

        public ActionResult Rented()
        {
            var userId = User.Identity.GetUserId();

            var rented = _unitOfWork.Rent.GetMyRents(userId);

            var model = rented.Select(r => new RentedViewModel
            {
                MovieId = r.MovieId,
                Title = r.Movie.Title,
                GenreName = r.Movie.Genre.Name,
                CreatedAt = r.CreatedAt.ToShortDateString()
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult Rent(int movieId)
        {
            Rent rent = new Rent
            {
                MovieId = movieId,
                UserId = User.Identity.GetUserId(),
                CreatedAt = DateTime.Now
            };

            _unitOfWork.Rent.AddRent(rent);

            _unitOfWork.CommitChanges();

            return RedirectToAction("Details", new { id = movieId });
        }

        [HttpPost]
        public ActionResult CancelRent(int movieId)
        {
            var userId = User.Identity.GetUserId();

            var rentToCancel = _unitOfWork.Rent.GetSingleRent(movieId, userId);

            _unitOfWork.Rent.RemoveRent(rentToCancel);

            _unitOfWork.CommitChanges();

            return RedirectToAction("Details", new { id = movieId });
        }
    }
}