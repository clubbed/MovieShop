using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Models
{
    // Composite Key table

    public class Rent
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MovieId { get; set; }

        public DateTime CreatedAt { get; set; }

        public ApplicationUser User { get; set; }
        public Movie Movie { get; set; }
    }
}