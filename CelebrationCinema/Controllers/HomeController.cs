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


namespace CelebrationAPI.Controllers
{
    public class HomeController : Controller
    {
        CelebrationContext db = new CelebrationContext();
        MoviesFavorite favoritesMovies = new MoviesFavorite();
        List<MoviesFavorite> movies = new List<MoviesFavorite>();


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
       
       public IActionResult MovieDetails(string Title)
        {
            //TODO: Add if validation in case the movie is not listed or user missspells
            string text = CallMovieAPI(Title);

            JToken t = JToken.Parse(text);
            Movies s = new Movies(t);

            return View(s);
        }  
        
        //  this past is still not working
        // TODO: add to Favorites 
       [HttpPost]
        public async Task<IActionResult> Favorites(MoviesFavorite u)
        {
            if (ModelState.IsValid)
            {
                db.MoviesFavorite.Add(u);
                 db.SaveChangesAsync();

                return RedirectToAction(nameof(Favorites));
            }
            else
            {
                return View(u);
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

