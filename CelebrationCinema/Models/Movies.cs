using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

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

        public Movies()
        {

        }

        public Movies(JToken u)
        {
            this.Title = u["Title"].ToString();
            this.Year = int.Parse(u["Year"].ToString());
            this.Rated = u["Rated"].ToString();
            this.Genre = u["Genre"].ToString();
            this.Director = u["Director"].ToString();
            this.Poster = u["Poster"].ToString();
        }
    }
}


