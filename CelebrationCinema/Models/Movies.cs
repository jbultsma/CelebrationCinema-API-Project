using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace CelebtationCinema.Models
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
            this.Title = u["title"].ToString();
            this.Year = int.Parse(u["year"].ToString());
            this.Rated = u["rated"].ToString();
            this.Genre = u["genre"].ToString();
            this.Director = u["director"].ToString();
            this.Poster = u["poster"].ToString();
        }
    }


