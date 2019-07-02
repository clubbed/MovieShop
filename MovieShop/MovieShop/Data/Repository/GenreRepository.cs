using MovieShop.Data.Interfaces;
using MovieShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieShop.Data.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        public void UpdateGenre(int id, Genre newGenre)
        {
            var oldGenre = _context.Genres.Where(g => g.Id == id).FirstOrDefault();

            _context.Entry(oldGenre).CurrentValues.SetValues(newGenre);
        }

        public void RemoveGenre(int id)
        {
            var genreToRemove = _context.Genres.Where(g => g.Id == id).FirstOrDefault();

            _context.Genres.Remove(genreToRemove);
        }
    }
}