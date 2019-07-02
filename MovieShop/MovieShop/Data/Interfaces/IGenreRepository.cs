using MovieShop.Models;
using System.Collections.Generic;

namespace MovieShop.Data.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();

        void AddGenre(Genre genre);
        void RemoveGenre(int id);
        void UpdateGenre(int id, Genre newGenre);
    }
}
