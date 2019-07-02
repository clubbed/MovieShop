using MovieShop.Data.Interfaces;
using MovieShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieShop.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _context { get; set; }

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetCount()
        {
            return _context.Users.Count();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users;
        }
    }
}