using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.ViewModels
{
    public class RentedViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string GenreName { get; set; }
        public string CreatedAt { get; set; }
    }
}