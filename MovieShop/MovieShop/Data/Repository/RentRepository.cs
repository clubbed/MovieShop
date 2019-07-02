using MovieShop.Data.Interfaces;
using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace MovieShop.Data.Repository
{
    public class RentRepository : IRentRepository
    {
        private readonly ApplicationDbContext _context;

        public RentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetCount()
        {
            return _context.Rents.Count();
        }

        public void AddRent(Rent rent)
        {
            _context.Rents.Add(rent);
        }

        public void RemoveRent(Rent rent)
        {
            _context.Rents.Remove(rent);
        }

        public Rent GetSingleRent(int movieId, string UserId)
        {
            return _context.Rents
                .Where(r => r.MovieId == movieId && r.UserId == UserId)
                .First();
        }

        public IEnumerable<Rent> GetRentsOfMovie(int movieId)
        {
            return _context.Rents.Where(r => r.MovieId == movieId)
                .Include(r => r.User)
                .Include(r => r.Movie)
                .Include(r => r.Movie.Genre);
        }

        public IEnumerable<Rent> GetMyRents(string userId)
        {
            return _context.Rents.Where(r => r.UserId == userId)
                .Include(r => r.User)
                .Include(r => r.Movie)
                .Include(r => r.Movie.Genre);
        }

        public IEnumerable<Rent> GetRents()
        {
            return _context.Rents
                .Include(r => r.User)
                .Include(r => r.Movie)
                .Include(r => r.Movie.Genre);
        }

    }
}