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

namespace CelebrationCinema.Controllers
{
    public class HomeController : Controller
    {
        public string CallMovieAPI()
        {

            HttpWebRequest request = WebRequest.CreateHttp($"http://www.omdbapi.com/?i=tt3896198&apikey=c794a6f9");
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