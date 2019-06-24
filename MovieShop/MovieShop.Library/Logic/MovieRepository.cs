using MovieShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Library.Logic
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public MovieRepository(MovieContext context): base(context)
        {

        }
    }
}
