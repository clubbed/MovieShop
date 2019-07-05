using System.Collections.Generic;

namespace MovieShop.ViewModels
{
    public class DetailsMovieViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string GenreName { get; set; }


        public IEnumerable<RentViewModel> Rent { get; set; }
        public string UserId { get; internal set; }
        public int Id { get; internal set; }
    }
}