using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mission6_Nimmer.Models;

namespace mission6_Nimmer.Controllers
{
    public class HomeController : Controller
    {


        private NewMovieContext _newMovieContext;

        public HomeController(NewMovieContext movie)
        {
            _newMovieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Joel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        [HttpPost]

        public IActionResult NewMovie(NewMovie response)
        {
            _newMovieContext.NewMovies.Add(response);
            _newMovieContext.SaveChanges();
            return View();
        }
    }
}
