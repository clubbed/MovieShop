using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repository
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
