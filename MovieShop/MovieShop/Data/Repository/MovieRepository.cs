using MovieShop.Data.Interfaces;
using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieShop.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetTodayMovies()
        {
            return _context.Movies.Where(m => m.CreatedDate.Date == DateTime.Today);
        }

        public int GetCount()
        {
            return _context.Movies.Count();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public IEnumerable<Movie> SearchMoviesByTitle(string search)
        {
            return _context.Movies.Where(movie => movie.Title.Contains(search))
                .Include(movie => movie.Genre);
        }

        public void Delete(int id)
        {
            var movieToDelete = _context.Movies.Where(movie => movie.Id == id).SingleOrDefault();

            if (movieToDelete != null)
                _context.Movies.Remove(movieToDelete);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.Include(m => m.Genre);
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.Where(m => m.Id == id)
                .Include(m => m.User)
                .Include(m => m.Genre)
                .FirstOrDefault();
        }

        public void Update(int id, Movie updatedMovie)
        {
            var previousMovie = _context.Movies.Where(movie => movie.Id == id).FirstOrDefault();

            _context.Entry(previousMovie).CurrentValues.SetValues(updatedMovie);
        }
    }
}
