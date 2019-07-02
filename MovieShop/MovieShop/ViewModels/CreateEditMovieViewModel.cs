using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.ViewModels
{
    public class CreateEditMovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        [Required]
        [DisplayName("Image Url")]
        public string ImagePath { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}