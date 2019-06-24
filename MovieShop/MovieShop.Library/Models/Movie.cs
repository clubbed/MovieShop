using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Library.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Original_Language { get; set; }
        public DateTime Release_Date { get; set; }
        public bool IsOutOfStock { get; set; }
        public decimal Price { get; set; }
    }
}
