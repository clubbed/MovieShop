using System;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }

        public ApplicationUser User { get; set; }
    }
}