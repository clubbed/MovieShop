using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieShop.Library.Models;

namespace MovieShop.Library.Logic
{
    public class MovieInitializer : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            IEnumerable<Movie> list = new List<Movie>()
            {
                new Movie {Id =1 , Title="demo", Price = 2m, Overview = "aye,aye", IsOutOfStock = false, Release_Date = DateTime.Today}
            };
            context.Movies.AddRange(list);
            base.Seed(context);
        }
    }
}
