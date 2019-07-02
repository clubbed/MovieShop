using MovieShop.Data.Interfaces;
using MovieShop.Models;

namespace MovieShop.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IMovieRepository Movie { get; set; }
        public IGenreRepository Genre { get; set; }
        public IRentRepository Rent { get; set; }
        public IUserRepository User { get; set; }

        public UnitOfWork(
            ApplicationDbContext context,
            IMovieRepository movie,
            IGenreRepository genre,
            IRentRepository rent,
            IUserRepository user
            )
        {
            _context = context;
            Movie = movie;
            Genre = genre;
            Rent = rent;
            User = user;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}