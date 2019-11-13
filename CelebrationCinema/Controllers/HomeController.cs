using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CelebrationCinema.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CelebrationCinema.Controllers
{
    public class HomeController : Controller
    {
        MoviesContext db = new MoviesContext();
        List<Movies> movies = new List<Movies>();
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string CallMovieAPI(string Title)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"http://www.omdbapi.com/?apikey=c794a6f9&t=" + Title);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //This will convert the response to a string
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }

        public JToken ParseJsonString(string text)
        {
            JToken output = JToken.Parse(text);
            return output;
        }

        public IActionResult MoviesDetail(string Title)
        {
            //TODO: Add if validation in case the movie is not listed or user missspells
            string text = CallMovieAPI(Title);
            JToken t = JToken.Parse(text);
            Movies s = new Movies(t);
            return View(s);
        }
        
        public async Task<IActionResult> Favorites()
        {
            return View(await db.Movie.ToListAsync());
        }

        public IActionResult AddMovie(string Title)
        {
            string text = CallMovieAPI(Title);
            JToken t = JToken.Parse(text);
            Movies s = new Movies(t);

            if (s != null)
            {
                db.Movie.Add(s);
                db.SaveChangesAsync();
                return RedirectToAction(nameof(Favorites));
            }
            else
            {
                return RedirectToAction(nameof(MoviesDetail));
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}