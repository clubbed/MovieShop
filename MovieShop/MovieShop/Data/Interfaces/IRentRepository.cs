using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Interfaces
{
    public interface IRentRepository
    {
        IEnumerable<Rent> GetRents();
        IEnumerable<Rent> GetMyRents(string userId);
        IEnumerable<Rent> GetRentsOfMovie(int movieId);

        Rent GetSingleRent(int movieId, string UserId);

        int GetCount();

        void AddRent(Rent rent);
        void RemoveRent(Rent rent);
    }
}
