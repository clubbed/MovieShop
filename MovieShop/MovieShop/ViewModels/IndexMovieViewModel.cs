using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.ViewModels
{
    public class IndexMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string GenreName { get; set; }
        public string ReleasedDate { get; set; }

    }
}