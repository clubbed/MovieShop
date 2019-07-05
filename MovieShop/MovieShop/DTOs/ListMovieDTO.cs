using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.DTOs
{
    public class ListMovieDTO
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string GenreName { get; set; }
        public string CreatedDate { get; set; }
    }
}