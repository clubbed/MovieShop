using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public string UserId { get; set; }

        [Required]
        [DisplayName("Image Url")]
        public string ImagePath { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Genre Genre { get; set; }

    }
}