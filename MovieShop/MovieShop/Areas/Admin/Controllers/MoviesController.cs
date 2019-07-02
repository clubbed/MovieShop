using MovieShop.Data.Interfaces;
using MovieShop.DTOs;
using MovieShop.Models;
using MovieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.Areas.Admin.Controllers
{
    public class MoviesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            var viewModel = new CreateEditMovieViewModel
            {
                Genres = _unitOfWork.Genre.GetGenres()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddMovie(CreateEditMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AddMovie");

            var movie = new Movie
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                ImagePath = viewModel.ImagePath,
                GenreId = viewModel.GenreId,
                ReleaseDate = DateTime.Now
            };

            _unitOfWork.Movie.Add(movie);
            _unitOfWork.CommitChanges();

            return Json(movie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _unitOfWork.Movie.GetMovieById(id);

            var model = new CreateEditMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ImagePath = movie.ImagePath,
                ReleaseDate = movie.ReleaseDate,
                Genres = _unitOfWork.Genre.GetGenres(),
                GenreId = movie.GenreId
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovie(CreateEditMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("EditMovie", viewModel);

            var movie = new Movie
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                GenreId = viewModel.GenreId,
                ImagePath = viewModel.ImagePath,
                ReleaseDate = DateTime.Now
            };

            _unitOfWork.Movie.Update(viewModel.Id, movie);

            _unitOfWork.CommitChanges();

            return RedirectToAction("Movies", "Dashboard");
        }

        [HttpDelete]
        public ActionResult DeleteMovie(int id)
        {
            _unitOfWork.Movie.Delete(id);

            _unitOfWork.CommitChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListMovies()
        {
            var movies = _unitOfWork.Movie.GetAll();

            var movieData = movies.Select(m => new ListMovieDTO
            {
                MovieId = m.Id,
                Title = m.Title,
                GenreName = m.Genre.Name,
                ReleaseDate = m.ReleaseDate.ToShortDateString()
            });

            return Json(new { data = movieData }, JsonRequestBehavior.AllowGet);
        }
    }
}