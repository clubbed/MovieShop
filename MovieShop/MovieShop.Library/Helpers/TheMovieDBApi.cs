using MovieShop.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Library.Helpers
{
    public static class TheMovieDBApi
    {
        public static HttpClient client;

        static TheMovieDBApi()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<IEnumerable<Movie>> LoadMovies()
        {
            using (HttpResponseMessage response = await client.GetAsync("movie/top_rated?api_key=6e34470b3c175373241d9768eec78f6a&language=en-US&page=1"))
            {
                if(!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("There was an error while trying to fetch data from third party api");
                }

                var result = await response.Content.ReadAsAsync<IEnumerable<Movie>>();

                return result ?? new List<Movie>
                {
                    new Movie
                    {
                        Id = 1,
                        Title = "Blah Blah"
                    }
                };
            }
        }
    }
}
