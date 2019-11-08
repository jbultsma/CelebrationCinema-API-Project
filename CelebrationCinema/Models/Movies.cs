using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebrationCinema.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Poster { get; set; }
    }
}
