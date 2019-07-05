using MovieShop.Models;
using System.Collections.Generic;

namespace MovieShop.Data.Interfaces
{
    public interface IMovieRepository
    {
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> SearchMoviesByTitle(string search);

        int GetCount();
        IEnumerable<Movie> GetTodayMovies();

        void Add(Movie movie);
        void Update(int id, Movie updatedMovie);
        void Delete(int id);
    }
}
